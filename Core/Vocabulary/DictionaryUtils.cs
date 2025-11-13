using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Re.C.Vocabulary;

public static class DictionaryUtils
{
    public readonly ref struct DictionaryValue<K, V>(ref V value)
    {
        public readonly ref V Value = ref value;
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

    public static bool GetOrInsertDefault<K, V>(this Dictionary<K, V> self, K key, out DictionaryValue<K, V> value)
        where K : notnull
    {
        value = new(ref CollectionsMarshal.GetValueRefOrAddDefault(self, key, out var exists)!);
        return exists;
    }

    public static void Add<K, V>(this Dictionary<K, V> self, (K, V) tuple)
        where K : notnull
    {
        self.Add(tuple.Item1, tuple.Item2);
    }
}
