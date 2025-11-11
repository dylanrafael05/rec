using System.Runtime.CompilerServices;

namespace Re.C.Types;

public class ErrorType : RecType
{
    public override string Name => "<error>";
    public override string FullName => "<error>";

    public override bool Equals(RecType? other)
        => other is ErrorType;
    public override int GetHashCode()
        => RuntimeHelpers.GetHashCode(this);
}