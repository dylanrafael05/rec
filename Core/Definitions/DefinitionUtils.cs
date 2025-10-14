using System.Text;

namespace Re.C.Definitions;

public static class DefinitionUtils
{
    extension<Definition>(Definition self)
        where Definition : IDefinition
    {
        public void BuildFullName(StringBuilder builder)
        {
            if (self.Parent is not null)
            {
                self.Parent.BuildFullName(builder);

                if (self.Identifier.IsID)
                    return;

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
