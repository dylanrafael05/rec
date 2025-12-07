namespace Re.C.IR;

[DiscriminatedUnion]
public partial record struct ArrayConstruction
{
    public static class Cases
    {
        public record struct Direct(ValueRef[] Values)
        {
            public override readonly string ToString()
                => $"array [{string.Join(", ", Values)}]";

            public readonly void GetArguments(IList<ValueRef> args)
            {
                foreach(var val in Values)
                    args.Add(val);
            }
        }

        public record struct Duplication(ValueRef Value, ValueRef Count)
        {
            public override readonly string ToString()
                => $"array [{Value}; {Count}]";

            public readonly void GetArguments(IList<ValueRef> args)
            {
                args.Add(Value);
                args.Add(Count);
            }
        }

        public record struct Raw(ValueRef Ptr, ValueRef Count)
        {
            public override readonly string ToString()
                => $"array [{Ptr} ;; {Count}]";
            
            public readonly void GetArguments(IList<ValueRef> args)
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

    public void GetArguments(IList<ValueRef> args)
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
