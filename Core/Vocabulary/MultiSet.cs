using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Re.C.Vocabulary;

public class MultiSet<T> : ICollection<T>, IReadOnlyCollection<T>
    where T : notnull
{
    private readonly Dictionary<T, int> refCounts = [];

    public int Count => refCounts.Count;
    public bool IsReadOnly => false;

    public void Add(T item)
    {
        refCounts.GetOrInsertDefault(item, out var rc);
        rc.Value++;
    }

    public void Clear()
    {
        refCounts.Clear();
    }

    public bool Contains(T item)
    {
        return refCounts.ContainsKey(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        refCounts.Keys.CopyTo(array, arrayIndex);
    }

    public Dictionary<T, int>.KeyCollection.Enumerator GetEnumerator()
        => refCounts.Keys.GetEnumerator();

    public bool Remove(T item)
    {
        var value = refCounts.GetOptional(item);

        if(value.IsSome)
        {
            value.Value--;

            if(value.Value == 0)
                refCounts.Remove(item);

            return true;
        }

        return false;
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}