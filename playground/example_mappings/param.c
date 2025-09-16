/*

SOURCE CODE:

template T
fn take(value T)
{

}

fn main() int
{
    take(1);
    return 0;
}

*/

#include "common.h"
#include <stddef.h>
#include <memory.h>

void take(struct rec_typeinfo *T, void *value)
{
    unsigned int __T_size = T->ty_size;

    void *__value = alloca_maxalign(__T_size);
    memcpy(__value, value, __T_size);

    T->ty_destructor(__value, NULL);
}

static struct rec_typeinfo rec_typeinfo__int = {
    .ty_name        = "int",
    .ty_size        = sizeof(int),
    .ty_align       = _Alignof(int),
    .ty_field_count = 0,
    .ty_fields      = NULL,
    .ty_destructor  = &trivial_destructor
};

int main()
{
    int __temp_0 = 1;
    take(&rec_typeinfo__int, &__temp_0);
}