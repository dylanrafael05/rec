namespace Re.C.Vocabulary;

public static class TempCollections<T, C>
    where C : class, ICollection<T>, new()
{
    private static readonly Stack<C> free = [];

    public readonly struct Disposable(C inner) : IDisposable
    {
        private readonly C inner = inner;
        public C Value => inner;

        public void Dispose()
        {
            Free(inner);
        }
    }

    public static C GetCollection()
    {
        if(free.Count > 0)
        {
            return free.Pop();
        }

        return new();
    }

    public static Disposable Get()
    {
        return new(GetCollection());
    }

    public static void Free(C collection)
    {
        collection.Clear();
        free.Push(collection);
    }
}

public static class Temporary
{
    public static TempCollections<T, List<T>>.Disposable List<T>()
        => TempCollections<T, List<T>>.Get();
    public static TempCollections<T, HashSet<T>>.Disposable HashSet<T>()
        => TempCollections<T, HashSet<T>>.Get();
    public static TempCollections<KeyValuePair<K, V>, Dictionary<K, V>>.Disposable Dictionary<K, V>()
        where K : notnull
        => TempCollections<KeyValuePair<K, V>, Dictionary<K, V>>.Get();
}