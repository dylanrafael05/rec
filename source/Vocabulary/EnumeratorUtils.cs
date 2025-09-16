namespace Re.C.Vocabulary;

public static class EnumeratorUtils
{
    extension<T>(IEnumerable<T> self)
    {
        public IEnumerable<(T value, int index)> Indexed
            => self.Select((value, index) => (value, index));
    }
}
