using EnumStringValues;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.Library.Enums
{
    public enum PersonTypeEnum
    {
        [StringValue("Doktor")]
        Doctor,
        [StringValue("Hasta")]
        Patient,
        [StringValue("Sekreter")]
        Secretary
    }
}
