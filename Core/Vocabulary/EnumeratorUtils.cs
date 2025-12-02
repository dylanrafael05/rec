namespace Re.C.Vocabulary;

public static class EnumeratorUtils
{
    extension<T>(IEnumerable<T> self)
    {
        public IEnumerable<(T value, int index)> Indexed
            => self.Select((value, index) => (value, index));

        public int SequenceHashCode()
        {
            var hashcode = 0;
            
            foreach (var value in self)
                hashcode = HashCode.Combine(hashcode, value);

            return hashcode;
        }
    }

    extension<T>(IReadOnlyList<T> self)
    {
        public Option<int> FindFirstIndex(Predicate<T> pred)
        {
            for(var i = 0; i < self.Count; i++)
                if(pred(self[i]))
                    return Option.Some(i);

            return Option.None;
        }

        public Option<int> FindLastIndex(Predicate<T> pred)
        {
            for(var i = self.Count - 1; i >= 0; i--)
                if(pred(self[i]))
                    return Option.Some(i);

            return Option.None;
        }
    }
}
