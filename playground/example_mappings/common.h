#pragma once

// Forward declarations //
struct rec_fieldinfo;
struct rec_typeinfo;

// Definitions //
typedef void (rec_destructor)(void *value, void *context);

struct rec_fieldinfo
{
    unsigned int          fld_offset;
    struct rec_typeinfo  *fld_type;
    char                 *fld_name;
};

struct rec_typeinfo
{
    char                  *ty_name;
    unsigned int           ty_size;
    unsigned int           ty_align;
    unsigned int           ty_field_count;
    struct rec_fieldinfo  *ty_fields;
    rec_destructor        *ty_destructor;
};

void *alloca_maxalign(unsigned int size);
void trivial_destructor(void *value, void *context);