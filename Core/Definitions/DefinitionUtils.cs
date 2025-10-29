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

        public string FullName
        {
            get
            {
                var result = new StringBuilder();
                self.BuildFullName(result);

                return result.ToString();
            }
        }
    }
}
