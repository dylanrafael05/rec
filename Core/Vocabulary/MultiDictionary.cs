using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Re.C.Vocabulary;

public class MultiDictionary<K, V>(bool allowDuplicateValues = true) 
    : IReadOnlyDictionary<K, IReadOnlyCollection<V>>
    where K : notnull
{
    private readonly Dictionary<K, ICollection<V>> inner = [];
    private Func<ICollection<V>> collectionConstructor = allowDuplicateValues
            ? () => (List<V>)[]
            : () => (HashSet<V>)[];
    private int totalCount = 0;
    
    int IReadOnlyCollection<KeyValuePair<K, IReadOnlyCollection<V>>>.Count 
        => inner.Count;
    public int KeyCount => inner.Count;
    public int ValueCount => totalCount;

    public IReadOnlyCollection<V> this[K key] => (IReadOnlyCollection<V>) inner[key];
    public bool TryGetValue(K key, [NotNullWhen(true)] out IReadOnlyCollection<V>? value)
    {
        if(inner.TryGetValue(key, out var result))
        {
            value = (IReadOnlyCollection<V>)result;
            return true;
        }

        value = default;
        return false;
    }

    public void Add(K key, V value)
    {
        if(!inner.GetOrInsertDefault(key, out var collection))
        {
            collection.Value = collectionConstructor();
        }

        collection.Value.Add(value);
        totalCount++;
    }

    public void Remove(K key)
    {
        if(!inner.TryGetValue(key, out var value))
            return;

        totalCount -= value.Count;
        inner.Remove(key);
    }
    
    public bool ContainsKey(K key)
        => inner.ContainsKey(key);

    public IEnumerable<K> Keys => inner.Keys;
    IEnumerable<IReadOnlyCollection<V>> IReadOnlyDictionary<K, IReadOnlyCollection<V>>.Values 
        => inner.Values.Cast<IReadOnlyCollection<V>>();
    public IEnumerable<V> Values => inner.Values.SelectMany(x => x);

    public readonly struct Enumerator(MultiDictionary<K, V> dictionary)
        : IEnumerator<KeyValuePair<K, IReadOnlyCollection<V>>>
    {
        private readonly Dictionary<K, ICollection<V>>.Enumerator enumerator 
            = dictionary.inner.GetEnumerator();

        public KeyValuePair<K, IReadOnlyCollection<V>> Current
        {
            get
            {
                var kvp = enumerator.Current;
                return new(kvp.Key, (IReadOnlyCollection<V>)kvp.Value);
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
            => enumerator.Dispose();

        public bool MoveNext()
            => enumerator.MoveNext();

        public readonly void Reset()
            => ((IEnumerator)enumerator).Reset();
    }

    public Enumerator GetEnumerator()
        => new(this);

    IEnumerator<KeyValuePair<K, IReadOnlyCollection<V>>> IEnumerable<KeyValuePair<K, IReadOnlyCollection<V>>>.GetEnumerator()
        => GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}