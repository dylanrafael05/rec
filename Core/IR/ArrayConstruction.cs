namespace Re.C.IR;

[DiscriminatedUnion]
public partial record struct ArrayConstruction
{
    public static class Cases
    {
        public record struct Direct(ValueID[] Values)
        {
            public override readonly string ToString()
                => $"array [{string.Join(", ", Values)}]";

            public readonly void GetArguments(IList<ValueID> args)
            {
                foreach(var val in Values)
                    args.Add(val);
            }
        }

        public record struct Duplication(ValueID Value, ValueID Count)
        {
            public override readonly string ToString()
                => $"array [{Value}; {Count}]";

            public readonly void GetArguments(IList<ValueID> args)
            {
                args.Add(Value);
                args.Add(Count);
            }
        }

        public record struct Raw(ValueID Ptr, ValueID Count)
        {
            public override readonly string ToString()
                => $"array [{Ptr} ;; {Count}]";
            
            public readonly void GetArguments(IList<ValueID> args)
            {
                args.Add(Ptr);
                args.Add(Count);
            }
        }
    }

    public override string ToString()
    {
        if(MatchesDirect)
            return UnwrapAsDirect().ToString();

        if(MatchesDuplication)
            return UnwrapAsDuplication().ToString();

        if(MatchesRaw)
            return UnwrapAsRaw().ToString();

        throw Unimplemented;
    }

    public void GetArguments(IList<ValueID> args)
    {
        if(MatchesDirect)
            UnwrapAsDirect().GetArguments(args);

        else if(MatchesDuplication)
            UnwrapAsDuplication().GetArguments(args);

        else if(MatchesRaw)
            UnwrapAsRaw().GetArguments(args);

        else throw Unimplemented;
    }
}
