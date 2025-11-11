using System.Collections.Immutable;

namespace Re.C.Passes;

/// <summary>
/// A helper class wrapping a list of passes to be applied
/// in sequential-parallel order.
/// </summary>
public readonly struct PassList(ImmutableArray<BasePass> all)
{
    public ImmutableArray<BasePass> All { get; } = all;
}