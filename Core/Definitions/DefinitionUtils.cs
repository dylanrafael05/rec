using System.Text;

namespace Re.C.Definitions;

public static class DefinitionUtils
{
    extension<Definition>(Definition self)
        where Definition : IDefinition
    {
        public void BuildFullName(StringBuilder builder)
        {
            if (self.IsLinked && self.Parent is not null && self.Parent.Identifier.IsName(out _))
            {
                self.Parent.BuildFullName(builder);
                builder.Append("::");
            }
            
            builder.Append(self.Identifier);
        }

        private void BuildFullIdentifier(List<Identifier> builder)
        {
            if (self.IsLinked && self.Parent is not null && self.Parent.Identifier.IsName(out _))
            {
                self.Parent.BuildFullIdentifier(builder);
            }
            
            builder.Add(self.Identifier);
        }

        private bool MatchesID(LongIdentifier id, int end)
        {
            if(end < 0)
                return false;

            if(id.Parts[end] != self.Identifier)
                return false;

            if(self.IsLinked && self.Parent is not null)
                return self.Parent.MatchesID(id, end + 1);

            return true;
        }

        public string FullName
        {
            get
            {
                var result = new StringBuilder();
                self.BuildFullName(result);

                return result.ToString();
            }
        }

        public LongIdentifier FullIdentifier
        {
            get
            {
                var result = new List<Identifier>();
                self.BuildFullIdentifier(result);

                return new([.. result]);
            }
        }

        public bool MatchesID(LongIdentifier id)
            => self.MatchesID(id, id.Parts.Count - 1);
    }
}
