using System.Runtime.InteropServices;

namespace Re.C.Vocabulary;

public static class DictionaryUtils
{
    public readonly ref struct DictionaryValue<K, V>(ref V value)
    {
        public readonly ref V Value = ref value;
    }

    public static bool GetOrInsertDefault<K, V>(this Dictionary<K, V> self, K key, out DictionaryValue<K, V> value)
        where K : notnull
    {
        value = new(ref CollectionsMarshal.GetValueRefOrAddDefault(self, key, out var exists)!);
        return exists;
    }
}
