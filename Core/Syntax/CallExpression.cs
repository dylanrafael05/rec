using OneOf;
using Re.C.Definitions;
using Re.C.Visitor;

namespace Re.C.Syntax;

public class CallExpression : Expression
{
    public readonly record struct DirectTarget(Expression Function);
    public readonly record struct MethodTarget(Expression Receiver, Function Function);

    public required OneOf<DirectTarget, MethodTarget> Target { get; init; }
    public required Expression[] Args { get; init; }

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(Target switch
        {
            { Index: 0 } => Target.AsT0.Function,
            { Index: 1 } => Target.AsT1.Receiver,

            _ => throw Unreachable
        });

        visitor.VisitMany(Args);
    }
}