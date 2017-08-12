using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public enum DeliveryStatus
    {
        [Display(Description = "GhnReadyToPick", ResourceType = typeof(LinhNguyen.Resources.Resources))]
        ReadyToPick,//	Chờ lấy hàng
        [Display(Description = "GhnPicking", ResourceType = typeof(Resources.Resources))]
        Picking,//	Đang lấy hàng
        [Display(Description = "GhnStoring", ResourceType = typeof(Resources.Resources))]
        Storing,// Lưu kho
        [Display(Description = "GhnDelivering", ResourceType = typeof(Resources.Resources))]
        Delivering,// Đang giao hàng
        [Display(Description = "GhnDelivered", ResourceType = typeof(Resources.Resources))]
        Delivered,// Đã giao hàng
        [Display(Description = "GhnWaitingToFinish", ResourceType = typeof(Resources.Resources))]
        WaitingToFinish,//	Đơn hàng đã được chuyển sang chờ thanh toán
        [Display(Description = "GhnFinish", ResourceType = typeof(Resources.Resources))]
        Finish,//	Kết thúc đơn hàng
        [Display(Description = "GhnReturn", ResourceType = typeof(Resources.Resources))]
        Return,//	Đơn hàng được trả lại
        [Display(Description = "GhnCancel", ResourceType = typeof(Resources.Resources))]
        Cancel //	Hủy đơn hàng
    }

    public enum ShippingType
    {
        [Display(Description = "GhnSupper", ResourceType = typeof(Resources.Resources))]
        GhnSupper = 17,//	Gói siêu tốc (kiện)
        [Display(Description = "GhnSaving", ResourceType = typeof(Resources.Resources))]
        GhnSaving = 18,//	Gói tiết kiệm (kiện)

        [Display(Description = "GhnSixHours", ResourceType = typeof(Resources.Resources))]
        GhnSixHours = 53319,//	Gói 6 giờ
        [Display(Description = "GhnOneday", ResourceType = typeof(Resources.Resources))]
        GhnOneday = 53320,//	Gói 1 ngày
        [Display(Description = "GhnTwoDay", ResourceType = typeof(Resources.Resources))]
        GhnTwoDay = 53321,//	Gói 2 ngày
        [Display(Description = "GhnThreeDay", ResourceType = typeof(Resources.Resources))]
        GhnThreeDay = 53322,//	Gói 3 ngày
        [Display(Description = "GhnFourDay", ResourceType = typeof(Resources.Resources))]
        GhnFourDay = 53323,//	Gói 4 ngày
        [Display(Description = "GhnFiveDay", ResourceType = typeof(Resources.Resources))]
        GhnFiveDay = 53324, //	Gói 5 ngày

        [Display(Description = "GhnPrime", ResourceType = typeof(Resources.Resources))]
        GhnPrime = 53325, //	Gói Prime

        [Display(Description = "GhnFourHours", ResourceType = typeof(Resources.Resources))]
        GhnFourHours = 53326, //	Gói 4 giờ

        [Display(Description = "GhnSixDay", ResourceType = typeof(Resources.Resources))]
        GhnSixDay = 53327, //	Gói 6 ngày

        [Display(Description = "GhnSixtyMinute", ResourceType = typeof(Resources.Resources))]
        GhnSixtyMinute = 53329, //	Gói 60 phút

        [Display(Description = "GhnPerson", ResourceType = typeof(Resources.Resources))]
        GhnPerson = 53330, //	Gói cá nhân

        [Display(Description = "Ghn226", ResourceType = typeof(Resources.Resources))]
        Ghn226 = 53339, //	Gói 226

        [Display(Description = "GhnCollect", ResourceType = typeof(Resources.Resources))]
        GhnCollect = 53346 //	Gói thu hộ
    }
}
