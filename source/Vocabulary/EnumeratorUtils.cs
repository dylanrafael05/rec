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
}
