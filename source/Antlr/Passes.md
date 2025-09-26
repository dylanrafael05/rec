The re:c compiler (after parsing and before code generation) implements
a multi-pass architecture. The passes are as follows:

1. **File-level declarations;** scopes defined by **mod** are resolved
2. **Type declarations;** types are defined but not created
3. **File-level definitions;** using declarations are resolved
4. **Type definitions;** types are created
5. **Function declarations;** functions are declared but not defined
6. **Function definitions;** functions and their contained expressions are compiled and type checked. This step produces the bound syntax tree