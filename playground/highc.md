```cpp
fn main() int
{
    // Define a variable
    var x int = 0;
    var c float = 0;

    // Define a constant variable
    let PI float = 3.14159;

    // Conditions -- braces are required to reduce ambiguity
    if x == 0
    {
        // ...
    }

    while x == 0
    {
        continue;
        break;
    }

    // Defer statements; execute in reverse order on scope close
    defer
    {
        // statements...
    }

    // Pointer types; const by defualt (use 'mut')

    // Return a value
    return 0;

}

// Define types
type int_buffer = [int; 256];
type int_slice = *[int];
type int_ptr = *int;

// ;
// Associated methods
fn float square(this) float
{
    return *this * *this;
}

fn use_square(x float)
{
    let xsq float = x.square();
}

// Structure types
struct Point
{
    x i32;
    y i32;
}

fn use_point()
{
    let point = new Point
    {
        x = 0;
        y = 1;
    };

    let x = point.x;
}

// Template types
template T
struct Pointer
{
    value *T;
}

// Template functions
template T
fn (Pointer T) get(this) *T
{
    // Automatic dereferencing
    return this.value;
}

// Multi-template types
template K V
struct Map
{
    // ...
}

type MapIntPointerInt = (Map int (Pointer int));

fn use_get()
{
    let ptr (Pointer int) = //...

    ptr.get();        // #1 - UFCS
    get(ptr&);        // #2 - template deduction
    (get int)(ptr&);  // #3 - explicit instanciation
}

// Traits
trait String
{
    fn get(this) char;
}

// Context (auto) parameters; inject at the callsite based on overload resolution
template K V
fn (Map K V) get(this, key *K, auto hash fn(key *K) int)
{
    // UFCS applies to function pointers as well!
    key.hash();
}

// Modules; code organization by namespaces

// flf.hc
mod flf
struct MyStruct {}

// main.hc
use flf
type MyAlias = MyStruct
type QualifiedAlias = flf.MyStruct
```