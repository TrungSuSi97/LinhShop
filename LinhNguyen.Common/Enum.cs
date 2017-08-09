using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Common
{
    public enum UserRole
    {
        Admin = 3,
        Master = 2,
        Normal = 1
    }

    public enum UserPaymentMethod
    {

        Using_Cash = 2,
        Internet_Banking = 1
    }

    public enum ProductSize
    {
        L = 1,
        S = 2,
        M = 3
    }

    public enum ShippingMethod
    {
        QuickDelivery = 1,
        Standard = 2
    }

    public enum CategoryType
    {
        Dam = 1,
        Chan_Vay = 2,
        Quan = 3,
        Ao = 4,
        Bo_Suu_Tap = 5,
        Jumpsuits = 6
    }

    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }

    public enum ProductColor
    {
        BEIGE = 1,
        BLACK = 2,
        BLUE = 3,
        BROWN = 4,
        GOLD = 5,
        GREEN = 6,
        GREY = 7,
        MULTI = 8,
        NAVY = 9,
        ORANGE = 10,
        PINK = 11,
        PURPLE = 12,
        RED = 13,
        SILVER = 14,
        WHITE = 15,
        YELLOW = 16
    }

    public enum SlideShowType
    {
        News = 1,
        Products = 2
    }
}
