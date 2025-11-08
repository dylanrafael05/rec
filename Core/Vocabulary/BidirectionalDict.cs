using System.Collections;

namespace Re.C.Vocabulary;

public interface IReadOnlyBimapping<A, B> : ICollection<(A, B)>
{
    public IReadOnlyDictionary<B, A> Firsts { get; }
    public IReadOnlyDictionary<A, B> Seconds { get; }
    
    public bool ContainsFirst(A key);
    public bool ContainsSecond(B key);

    public bool Contains(A key);
    public bool Contains(B key);
}

public class Bimapping<A, B> : ICollection<(A, B)>, IReadOnlyBimapping<A, B>
    where A : notnull
    where B : notnull
{
    private readonly Dictionary<A, B> aToB = [];
    private readonly Dictionary<B, A> bToA = [];

    public IReadOnlyDictionary<B, A> Firsts => bToA;
    public IReadOnlyDictionary<A, B> Seconds => aToB;

    public int Count => aToB.Count;
    public bool IsReadOnly => false;

    public void Add(A first, B second)
    {
        aToB.Add(first, second);
        bToA.Add(second, first);
    }

    public void RemoveFirst(A first)
    {
        if(aToB.TryGetValue(first, out var second))
        {
            aToB.Remove(first);
            bToA.Remove(second);
        }
    }
    public void RemoveSecond(B second)
    {
        if(bToA.TryGetValue(second, out var first))
        {
            aToB.Remove(first);
            bToA.Remove(second);
        }
    }
    public void Remove(A first) => RemoveFirst(first);
    public void Remove(B first) => RemoveSecond(first);

    public void Add((A, B) item)
        => Add(item.Item1, item.Item2);

    public void Clear()
    {
        aToB.Clear();
        bToA.Clear();
    }

    public bool ContainsFirst(A key)
        => aToB.ContainsKey(key);
    public bool ContainsSecond(B key)
        => bToA.ContainsKey(key);
    
    public bool Contains(A key)
        => ContainsFirst(key);
    public bool Contains(B key)
        => ContainsSecond(key);

    public bool Contains((A, B) item)
        => ContainsFirst(item.Item1) && Seconds[item.Item1].Equals(item.Item2);

    public void CopyTo((A, B)[] array, int arrayIndex)
    {
        var i = arrayIndex;
        foreach(var val in this)
            array[i++] = val;
    }

    public bool Remove((A, B) item)
    {
        if(Contains(item))
        {
            RemoveFirst(item.Item1);
            return true;
        }

        return false;
    }

    public IEnumerator<(A, B)> GetEnumerator()
    {
        foreach(var kvp in aToB)
            yield return (kvp.Key, kvp.Value);
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}
