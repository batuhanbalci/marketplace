using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceBlazorApp.Shared
{
    public enum Roles : byte
    {
        Kullanıcı = 0,
        Mağaza = 1,
        Editör = 2,
        Admin = 3,
        Engellenmiş = 4,
        Diğer = 5
    }

    public enum ItemStates : byte
    {
        Bekleyen = 0,
        Onaylanmış = 1,
        Kaldırılmış = 2,
        Diğer = 3
    }

    public enum PropertyUnitType : Int16 // TO DO
    {
        Gram,
        Kilogram,
        Ton,
        Santimetre,
        Metre,
        Kilometre,
        Dakika,
        Saat,
        Gün,
        Hafta,
        Ay,
        Yıl,
        Hz,
        Mhz,
        Ghz,
        Kilobyte,
        Megabyte,
        Gigabyte,
        Terabyte
    }

    public class Enums
    {

    }
}
