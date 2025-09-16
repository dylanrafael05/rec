/*

SOURCE CODE:

template T
struct Aged
{
    value T;
    age int;
}

template T
fn get_age(value *(Aged T)) int
{
    return value.age;
}

fn main() int
{
    var value = new (Aged char) { 
        value = '0', 
        age = 10
    };

    get_age(&value);

    return 0;
}

*/

#include "common.h"
#include <stddef.h>
#include <memory.h>

struct Aged_char
{
    char value;
    int age;
};

static struct rec_typeinfo rec_typeinfo__char; // ...
static struct rec_typeinfo rec_typeinfo__int;  // ...

static struct rec_fieldinfo rec_fields__Aged_char[] = {
    (struct rec_fieldinfo){
        .fld_offset = offsetof(struct Aged_char, value),
        .fld_name = "value",
        .fld_type = &rec_typeinfo__char
    },
    (struct rec_fieldinfo){
        .fld_offset = offsetof(struct Aged_char, age),
        .fld_name = "age",
        .fld_type = &rec_typeinfo__int
    }
};

static struct rec_typeinfo rec_typeinfo__Aged_char = {
    .ty_name        = "(Aged char)",
    .ty_size        = sizeof(struct Aged_char),
    .ty_align       = _Alignof(struct Aged_char),
    .ty_field_count = 2,
    .ty_fields      = rec_fields__Aged_char,
    .ty_destructor  = &trivial_destructor
};

int get_age(struct rec_typeinfo *T, void *value)
{
    struct rec_fieldinfo *__field = T->ty_fields + 1;
    unsigned int __field_offset = __field->fld_offset;

    int *__field_ptr = (int*)((char*)value + __field_offset);
    return *__field_ptr;
}

int main()
{
    struct Aged_char value;
    value.value = '0';
    value.age = 10;
    
    get_age(&rec_typeinfo__Aged_char, &value);
}