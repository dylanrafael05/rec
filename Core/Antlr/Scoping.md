Associated functions can be bound to any type (or specializations thereof)

```rs
mod float_utils as float

fn sqrt(self) float
{
    // ...
}

fn zero() float
{
    // ...
}

end mod
```

'Default' modules (unnamed) can appear in the same file as the type
they are associated with.

```rs
mod as mystruct

end mod
```