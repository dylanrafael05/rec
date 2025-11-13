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

    /// <summary>
    /// A variant of Scoped which does not necessarily contain a valid value.
    /// </summary>
    public class Optional
    {
        public Option<T> Current { get; private set; } = Option.None;
        private Stack<T> Stack { get; } = [];

        public void Enter(T value)
        {
            if(Current.IsSome(out var cur))
                Stack.Push(cur);

            Current = Option.Some(value);
        }

        public T Exit()
        {
            var cur = Current.Unwrap();
            Current = Stack.Count is 0 ? Option.Some(Stack.Pop()) : Option.None;

            return cur;
        }
    }
}
