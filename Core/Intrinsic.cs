namespace Re.C;

public enum Intrinsic
{
    [EnumRepr("leak")] Leak,
    [EnumRepr("store_uninit")] StoreUninit,
}