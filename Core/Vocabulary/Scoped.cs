namespace Re.C.Vocabulary;

/// <summary>
/// Represents data whose value can be set and restored as though 
/// nested, like parentheses.
/// </summary>
public class Scoped<T>(T init)
{
    public T Current { get; private set; } = init;
    private Stack<T> Stack { get; } = [];

    public void Enter(T value)
    {
        Stack.Push(Current);
        Current = value;
    }

    public T Exit()
    {
        var cur = Current;
        Current = Stack.Pop();

        return cur;
    }
}
