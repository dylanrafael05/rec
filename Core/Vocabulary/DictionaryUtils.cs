using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Re.C.Vocabulary;

public static class DictionaryUtils
{
    public struct UninitDictionaryEntry<K, V>(IDictionary<K, V> dict, K key, Option<V> value)
    {
        private readonly IDictionary<K, V> dict = dict;
        private readonly K key = key;
        private Option<V> value = value;

        public readonly bool IsInitialized 
            => value.MatchesSome;

        public V Value
        {
            get
            {
                if(value.IsNone)
                {
                    var def = default(V);
                    value = Option.Some(def!);
                    dict.Add(key, def!);
                }

                return value.Unwrap();
            }

            set
            {
                this.value = Option.Some(value);
                dict[key] = value; 
            }
        }
    }

    public readonly ref struct OptionalDictionaryValue<K, V>(ref V value)
    {
        private readonly ref V value = ref value;

        public bool IsNone => Unsafe.IsNullRef(ref value);
        public bool IsSome => !IsNone;
        public ref V Value 
        {
            get 
            {
                if(IsNone)
                    throw new InvalidOperationException($"Access to 'Value' when IsNone");
                    
                return ref value;
            }
        }
    }

    public static OptionalDictionaryValue<K, V> GetOptional<K, V>(this Dictionary<K, V> self, K key)
        where K : notnull
    {
        return new(ref CollectionsMarshal.GetValueRefOrNullRef(self, key));
    }

    public static bool GetOrInsertDefault<K, V>(this Dictionary<K, V> self, K key, out UninitDictionaryEntry<K, V> value)
        where K : notnull
    {
        if(self.TryGetValue(key, out var initValue))
        {
            value = new(self, key, Option.Some(initValue));
            return true;
        }

        value = new(self, key, Option.None);
        return false;
    }

    public static void Add<K, V>(this Dictionary<K, V> self, (K, V) tuple)
        where K : notnull
    {
        self.Add(tuple.Item1, tuple.Item2);
    }
}
