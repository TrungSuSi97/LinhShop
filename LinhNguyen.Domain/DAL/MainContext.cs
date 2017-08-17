using LinhNguyen.Common;
using LinhNguyen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace LinhNguyen.Domain
{
    public class MainContext : DbContext
    {
        public MainContext() : base(nameof(MainContext))
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<CompanyInfo> CompanyInfo { get; set; }
        public DbSet<MainSlideShow> SlideShow { get; set; }
        public DbSet<Coupons> Coupons { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ShippingAddress> ShippingAddress { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            //Database.SetInitializer<MainContext>(null);
            //base.OnModelCreating(modelBuilder);
            // Add any configuration or mapping stuff here
            modelBuilder.Entity<Resource>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                   new IndexAnnotation(new IndexAttribute("IX_NameCulture", 1) { IsUnique  = true}));

            modelBuilder.Entity<Resource>()
                .Property(t => t.Culture)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                   new IndexAnnotation(new IndexAttribute("IX_NameCulture", 2) { IsUnique = true }));
        } 

        protected void Seed(MainContext context)
        {
            var user1 = new User
            {
                FullName = "Cao Hoang Sang",
                UserName = "sangcao",
                Password = CommonFunc.CalculateMD5Hash("sangcao21021985"),
                ConfirmPassword = CommonFunc.CalculateMD5Hash("sangcao21021985"),
                CreatedDate = DateTime.Now,
                Role = UserRole.Master,
                Email = "caohoangsang.it@gmail.com",
                Address = "Nhà số 4, Hẻm số 14, Nguyễn Văn Linh, Huyện Hòa Thành, Tỉnh Tây Ninh",
                Address1 = "Nhà số 4, Hẻm số 14, Nguyễn Văn Linh, Huyện Hòa Thành, Tỉnh Tây Ninh",
                PhoneNumber = "0917044714",
                DateOfBirth = DateTime.Today,
                IsActive = true,
                ImagePath = "~/images/user/user.png"
            };

            var pass = WebConfigurationManager.AppSettings["DefaultPass"].ToString();
            if (string.IsNullOrEmpty(pass))
            {
                pass = "";
            }

            var user2 = new User
            {
                FullName = "Van Phạm",
                UserName = "vanpham",
                Password = CommonFunc.CalculateMD5Hash(pass),
                ConfirmPassword = CommonFunc.CalculateMD5Hash(pass),
                CreatedDate = DateTime.Now,
                Role = UserRole.Master,
                Email = "ysme.fashion@gmail.com",
                Address = "TPHCM",
                Address1 = "TPHCM",
                PhoneNumber = "090 8778 646",
                DateOfBirth = DateTime.Today,
                IsActive = true,
                ImagePath = "~/images/user/user.png"
            };

            var user3 = new User
            {
                FullName = "Linh Nguyen",
                UserName = "linhnguyenhp88",
                Password = CommonFunc.CalculateMD5Hash("linhmueller12"),
                ConfirmPassword = CommonFunc.CalculateMD5Hash("linhmueller12"),
                CreatedDate = DateTime.Now,
                Role = UserRole.Admin,
                Email = "linhnguyenhp88@gmail.com",
                Address = "163 To Hien Thanh street, 10 District",
                Address1 = "TPHCM",
                PhoneNumber = "090 8778 646",
                DateOfBirth = DateTime.Today,
                IsActive = true,
                ImagePath = "~/images/user/user.png"
            };

            var products = new MainSlideShow
            {
                Title1 = "main slide1",
                Title2 = "main slide2",
                Title3 = "main slide3",
                Title4 = "main slide4",
                ImagePath1 = @"~/images/p-11.jpg",
                ImagePath2 = @"~/images/p-11.jpg",
                ImagePath3 = @"~/images/p-11.jpg",
                ImagePath4 = @"~/images/p-11.jpg",
                Type = SlideShowType.Products
            };

            var com = new CompanyInfo
            {
                Logan = "Just the way you are",
                Address = "Địa chỉ 468/2 Lê Văn Sỹ, Phường 14, Quận 3, HCM",
                Phone = "093 866 4506",
                Email = "msthanhvan148@gmail.com",
                Title = "YSME Fashion",
                HotLine = "090 8778 646",
                DateToChangeProduct = 7,
                FreeToDelivery = 500000,
                PathImageTransfer = "~/images/company-info/kerry.jpg",
                PathImageIdentity = "~/images/company-info/security.jpg",
                PathImageLogo = "~/images/company-info/logo.jpg",
                PathImagePaymentMethod = "~/images/company-info/creditcard.jpg",
                Copyright = "Copyright 2012 by YS ME",
                PercentForPoint = 10,
                NumberPointForPercent = 200,
                PickHubCode = "0210",
                PickHubText = "Quận 10",
                UsdExchange = 22000
            };

            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.SlideShow.Add(products);
            context.CompanyInfo.Add(com);

            #region VietName
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "About", Value = "Thông tin công ty" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "AboutUs", Value = "Về chúng tôi" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Accessories", Value = "Phụ kiện" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "AdditionalInformation", Value = "Thông tin thêm" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "AddOrder", Value = "Thêm sản phẩm" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Address1", Value = "Địa chỉ" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Address2", Value = "Địa chỉ liên hệ" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "AddressLong", Value = "Địa chỉ dài hơn 30 ký tự." });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "AddressRequired", Value = "Nhập địa chỉ" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "AddToCart", Value = "Thêm vào giỏ hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "AdminPassword", Value = "Mật khẩu admin" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "AnotherNews", Value = "Tin tức khác" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Ao", Value = "Áo" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "BestSeller", Value = "Hot items" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Birthday", Value = "Ngày sinh" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "BosuuTap", Value = "Bộ sưu tập" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Categories", Value = "Danh mục" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ChanVay", Value = "Chân váy" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ChatWithUs", Value = "Hỗ trợ trực tuyến" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "CheckOrder", Value = "Kiểm tra đơn hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Choose", Value = "Chọn" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ChoseIt", Value = "Chọn ngay" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ChosePaymentMethod", Value = "Phương thức thanh toán" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ChoseShipMethod", Value = "Hình thức vận chuyển" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ClearShoppingCart", Value = "Xóa giỏ hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Clothing", Value = "Quần áo" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Color", Value = "Màu" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Condition", Value = "Điều kiện" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ConditionChangeProduct", Value = "Điều kiện để trả hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ConfirmPassword", Value = "Nhập lại mật khẩu" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ConnectFacebook", Value = "Kết nối Facebook" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Contact", Value = "Liên hệ" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ContactError", Value = "Không thể gởi thông tin, đã có lỗi xảy ra!" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ContactInformation", Value = "Thông tin liên hệ" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ContactPhone", Value = "Điện thoại" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ContactSendOK", Value = "Gởi thông tin thành công" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ContactString", Value = "We are here to answer any questions you may have about our combadi experiences. Reach out to us and we'll respond as soon as we can. Even if there is something you have always wanted to experience and can't find it on combadi, let us know and we promise we'll do our best to find it for you and send you there." });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ContactUs", Value = "Liên hệ chúng tôi" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ContinueShopping", Value = "Tiếp tục Shopping" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "CreateAnAcount", Value = "Tạo mới tài khoản" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "CreatedDate", Value = "Ngày tạo" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "CustomerSupport", Value = "Hỗ trợ khách hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "DaGiaoHang", Value = "Đã giao hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "DangGiaoHang", Value = "Đang giao hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "DeliveryService", Value = "Dịch vụ vận chuyển" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "DiemDaDung", Value = "Điểm đã dùng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "DiscountCodes", Value = "Mã giảm giá" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "DiscountText", Value = "Ưu đãi" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Dress", Value = "Đầm" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Edit", Value = "Cập nhật" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "EditOrder", Value = "Sửa sản phẩm" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "EmailAddress", Value = "Email" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "EmailExisting", Value = "Email đã tồn tại" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "EmailInvalid", Value = "Email không hợp lệ" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "EmailLong", Value = "Email không được dài hơn 50 kí tự" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "EmailOrUsername", Value = "Email hoặc tên đăng nhập" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "EmailRequired", Value = "Nhập email" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "English", Value = "Tiếng anh" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "EnterComment", Value = "Nhập ghi chú" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "EnterEmail", Value = "Nhập email" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "EnterFullName", Value = "Nhập họ tên" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "EnterPhoneNumber", Value = "Nhập số điện thoại" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "EnterReduceCode", Value = "Nhập mã giảm giá" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "EnterShippingAddress", Value = "Nhập địa chỉ giao hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ErrorOccurHere", Value = "Xin lỗi, đã có lỗi xảy ra !" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Fee", Value = "Phí giao hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Female", Value = "Nữ" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ForgotPassword", Value = "Quên mật khẩu ?" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ForgotYourPassword", Value = "Quên mật khẩu?" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "FreeChangeAfter30Day", Value = "Miển phí đổi trả trong {0} ngày" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "FreeDelivery", Value = "Miễn phí giao hàng từ {0}" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "FullName", Value = "Họ tên" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "FullNameLong", Value = "Họ tên dài hơn 100 ký tự" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "FullNameRequired", Value = "Nhập họ tên" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GetAQuote", Value = "Nhận thông báo" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Gift", Value = "Quà tặng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GrandTotal", Value = "Tổng phải trả" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Hello", Value = "Xin chào" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "HighToLow", Value = "Giá giảm dần" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Home", Value = "Trang chủ" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "HotDeals", Value = "Ưu đãi" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "HotLine", Value = "Hot line" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Identity", Value = "Chứng nhận" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Image", Value = "Hình ảnh" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "InCountry", Value = "Nước ngoài" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "InputAddress", Value = "Địa chỉ" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "InternertBanking", Value = "Chuyển khoản ngân hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "InternetBanking", Value = "Thẻ ATM Internet Banking" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Jean", Value = "Đồ Jean" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "JobSupport", Value = "Tuyển dụng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Jumpsuits", Value = "Jumpsuits" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Language", Value = "Ngôn ngữ" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Like", Value = "Thích" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Login", Value = "Đăng nhập" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Logout", Value = "Logout" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "LowToHigh", Value = "Giá tăng dần" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Male", Value = "Nam" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Money", Value = "₫" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "NewArrival", Value = "Hàng mới về" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "NewCustomers", Value = "Khách hàng mới" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "News", Value = "Tin tức" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "NewTrend", Value = "Mẫu mới" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Note", Value = "Ghi chú" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Order", Value = "Đơn hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "OrderCode", Value = "Mã đơn hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "OrderStatus", Value = "Trạng thái" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Other", Value = "Khác" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "PageOf", Value = "Trang {0} của {1}" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Password", Value = "Mật khẩu" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "PasswordLong", Value = "{0} phải ít nhất {2} ký tự." });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Payment", Value = "Đặt mua" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "PaymentMethod", Value = "Phương thức thanh toán" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "PaymentNext", Value = "Đi tiếp" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "PaymentText", Value = "Bạn sẽ trả tiền khi nhận sản phẩm" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "PaymentType", Value = "Kiểu thanh toán" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "PaymentWizard", Value = "Đặt mua" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "PhoneRequired", Value = "Nhập điện thoại" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "PriceList", Value = "Biểu phí" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ProceedToCheckout", Value = "Đặt mua" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Product", Value = "Sản phẩm" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ProductDescription", Value = "Mô tả sản phẩm" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ProductName", Value = "Tên sản phẩm" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ProductSize", Value = "SIZE" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Quan", Value = "Quần" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Quantity", Value = "Số lượng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "QuestionAnwser", Value = "Hỏi và đáp" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "QuickDelivery", Value = "Giao nhận nhanh" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ReceivedProductAndPayment", Value = "Thanh toán khi nhận hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Register", Value = "Đăng ký" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "RegisteredCustomers", Value = "Khách hàng đã đăng ký" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "RegisterNewUser", Value = "Đăng ký người dùng mới " });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "RegularManagement", Value = "Quy chế quản lý" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Reguleration", Value = "Điều khoản" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "RememberMe", Value = "Ghi nhớ?" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Remove", Value = "Xóa" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "RemoveOrder", Value = "Xóa sản phẩm" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ReOrder", Value = "Tiếp tục mua hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "RePassword", Value = "Nhập lại mật khẩu" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "SaleCoperation", Value = "Hợp tác bán hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "SaleOff", Value = "Ưu đãi" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Search", Value = "Tìm kiếm" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "SelectDate", Value = "Chọn ngày" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "SelectShippingType", Value = "Chọn loại vận chuyển" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Send", Value = "Gởi đi" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Share", Value = "Chia sẻ" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ShippingAddress", Value = "Địa chỉ" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ShippingAddressLong", Value = "Địa chỉ dài hơn 500 ký tự" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ShippingToAddressRequired", Value = "Nhập địa chỉ" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ShippingType", Value = "Kiểu giao nhận" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ShipTo", Value = "Giao đến" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ShoppingCard", Value = "Giỏ hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ShoppingCart", Value = "Giỏ hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ShoppingComment", Value = "Nội dung" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ShoppingPhone", Value = "Điện thoại" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ShoppingPhoneLong", Value = "Điện thoại dài hơn 11 ký tự" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ShoppingPhoneRequired", Value = "Nhập điện thoại" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ShoppingReduceCode", Value = "Mã giảm giá" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ShoppingReduceCodeLong", Value = "Mã giảm giá dài hơn 15 ký tự" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Shoses", Value = "Giày" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Size", Value = "Size" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Sku", Value = "Sku" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "SortBy", Value = "Sắp sếp theo" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "SpecialOffers", Value = "Đăng ký để nhận ưu đãi đặc biệt từ YS ME Fashion" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Standard", Value = "Gói chuẩn" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Subject", Value = "Nọi dung" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "SubjectText", Value = "Nội dung" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "SubTotal", Value = "Chi tiết giá" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Support", Value = "Hỗ trợ" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Tab", Value = "Tab" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "TextNewCustomers", Value = "Bằng cách sở hữu tài khoản trong hệ thống bạn có thể thuận tiện hơn trong việc xem và mua sắm sản phẩm. và được hổ trợ dịch vụ tốt nhất. " });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "TextRegisteredCustomers", Value = "Đăng nhập nếu bạn đã có tài khoản trong hệ thống	" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UnitPrice", Value = "Giá" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UpdateAccount", Value = "Cập nhật" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UpdateShoppingCart", Value = "Cập nhật giỏ hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UpdateUserError", Value = "Không thể cập nhật, đã có lỗi xảy ra trong hệ thống!" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UserAddress1", Value = "Địa chỉ 1" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UserAddress1Required", Value = "Nhập địa chỉ" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UserAddress2", Value = "Địa chỉ 2" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UserBirthday", Value = "Ngày sinh" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UserEmail", Value = "Email" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UserImage", Value = "Hình ảnh" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "Username", Value = "Tên đăng nhập" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UsernameLong", Value = "Tên đăng nhập dài quá 50 ký tự" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UsernameRequired", Value = "Nhập tên đăng nhập" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UserPasswordRequired", Value = "Nhập mật khẩu" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UserPhone", Value = "Điện thoại" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UserPhoneRequired", Value = "Nhập số điện thoại" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UserRole", Value = "Quyền" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UsingCard", Value = "Thanh toán qua thẻ tín dụng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UsingCash", Value = "Tiền mặt" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "VietName", Value = "Tiếng việt" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ViewDetailOrder", Value = "Xem chi tiết sản phảm" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ViewOrder", Value = "Xem đơn hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "VisaMasterCard", Value = "Thẻ Visa, Master" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "WeGotYourEmail", Value = "Chúng tôi đã nhận được email của bạn !" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "WhatAreYouLookingFor", Value = "Bạn muốn tìm gì ?" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "WhatIsHot", Value = "Hàng Hot" });
            //UserProfile
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "UserProfile", Value = "Thông tin người dùng" });
            //ShoppingCommentLong
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ShoppingCommentLong", Value = "Ghi chú dài hơn 300 ký tự" });

            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GhnReadyToPick", Value = "Chờ lấy hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GhnPicking", Value = "Đang lấy hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GhnStoring", Value = "Lưu kho" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GhnDelivering", Value = "Đang giao hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GhnDelivered", Value = "Đã giao hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GhnWaitingToFinish", Value = "Đơn hàng đã được chuyển sang chờ thanh toán" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GhnFinish", Value = "Kết thúc đơn hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GhnReturn", Value = "Đơn hàng được trả lại" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GhnCancel", Value = "Hủy đơn hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GhnSixHours", Value = "Gói 6 giờ" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GhnOneday", Value = "Gói 1 ngày" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GhnTwoDay", Value = "Gói 2 ngày" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GhnThreeDay", Value = "Gói 4 ngày" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GhnFourDay", Value = "Gói 5 ngày" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "GhnFiveDay", Value = "Gói 6 ngày" });
            //OrderHistory
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "OrderHistory", Value = "Lược sử mua hàng" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ProvinceId", Value = "Tỉnh/Thành phố" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "ProvinceIdRequired", Value = "Nhập tỉnh/thành phố" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "SelectProvince", Value = "Chọn tỉnh thành phố" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "PleaseSelect", Value = "Vui lòng chọn..." });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "AboutYsme", Value = "About YSME" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "PlsSelectSize", Value = "Chon size" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "vi-VN", Name = "PlsSelectColor", Value = "Chon mau" });
            #endregion

            #region English
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "PlsSelectColor", Value = "Select color" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "PlsSelectSize", Value = "Select size" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "AboutYsme", Value = "About YSME" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "About", Value = "About" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "AboutUs", Value = "About Us" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Accessories", Value = "Phụ kiện" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "AdditionalInformation", Value = "Additional Information" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "AddOrder", Value = "Add  order item	" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Address1", Value = "Address" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Address2", Value = "Address 2" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "AddressLong", Value = "Address is longer than 300 ký tự." });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "AddressRequired", Value = "Address is required" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "AddToCart", Value = "Add to cart	" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "AdminPassword", Value = "Admin password" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "AnotherNews", Value = "Another news" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Ao", Value = "Shirts" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "BestSeller", Value = "Hot items" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Birthday", Value = "Birthday" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "BosuuTap", Value = "Lookbook" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Categories", Value = "Categories" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ChanVay", Value = "Skirts" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ChatWithUs", Value = "Chat with us" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "CheckOrder", Value = "Check Order" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Choose", Value = "Choose" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ChoseIt", Value = "Choose it" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ChosePaymentMethod", Value = "Chose Payment method" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ChoseShipMethod", Value = "Chose ship method" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ClearShoppingCart", Value = "Clear Shopping Cart" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Clothing", Value = "Clothing" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Color", Value = "Color" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Condition", Value = "Conditions" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ConditionChangeProduct", Value = "Condition to change product" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ConfirmPassword", Value = "Confirm password" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ConnectFacebook", Value = "Connect to Facebook" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Contact", Value = "Contact" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ContactError", Value = "Send contact failed!" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ContactInformation", Value = "Contact information" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ContactPhone", Value = "Phone number" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ContactSendOK", Value = "Send contact success!" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ContactString", Value = "We are here to answer any questions you may have about our combadi experiences. Reach out to us and we'll respond as soon as we can. Even if there is something you have always wanted to experience and can't find it on combadi, let us know and we promise we'll do our best to find it for you and send you there." });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ContactUs", Value = "Contact us" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ContinueShopping", Value = "Continue Shopping" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "CreateAnAcount", Value = "Create An Acount" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "CreatedDate", Value = "Created date" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "CustomerSupport", Value = "Customer support" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "DaGiaoHang", Value = "Delivered" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "DangGiaoHang", Value = "Waiting to delivery	" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "DeliveryService", Value = "Delivery service" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "DiemDaDung", Value = "Point is used" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "DiscountCodes", Value = "Discount Codes" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "DiscountText", Value = "Discount" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Dress", Value = "DRESS" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Edit", Value = "Edit" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "EditOrder", Value = "Edit  order item" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "EmailAddress", Value = "Email" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "EmailExisting", Value = "Email is existing in system" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "EmailInvalid", Value = "Email is not valid" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "EmailLong", Value = "Email no longer than 50 characters" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "EmailOrUsername", Value = "Email or Username" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "EmailRequired", Value = "Input email" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "English", Value = "English" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "EnterComment", Value = "Enter comment" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "EnterEmail", Value = "Input email" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "EnterFullName", Value = "Input fullname" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "EnterPhoneNumber", Value = "Input phone number" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "EnterReduceCode", Value = "Input reduce code" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "EnterShippingAddress", Value = "Enter shipping address" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ErrorOccurHere", Value = "Sorry ! we have error at here! " });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Fee", Value = "Delivery fee" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Female", Value = "Female" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ForgotPassword", Value = "Forgot Your Password ?" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ForgotYourPassword", Value = "Forgot Your Password ?" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "FreeChangeAfter30Day", Value = "Free change or return {0} days" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "FreeDelivery", Value = "Free delivery from {0}" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "FullName", Value = "Fullname" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "FullNameLong", Value = "Fullname does not longer than 100 characters" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "FullNameRequired", Value = "Enter fullname" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GetAQuote", Value = "Get A Quote	" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Gift", Value = "Gift" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GrandTotal", Value = "Grand Total" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Hello", Value = "Hello" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "HighToLow", Value = "High to Low" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Home", Value = "Home" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "HotDeals", Value = "HOT DEALS" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "HotLine", Value = "Hot line" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Identity", Value = "Identity" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Image", Value = "Image" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "InCountry", Value = "Foreign" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "InputAddress", Value = "Input address" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "InternertBanking", Value = "Internert banking" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "InternetBanking", Value = "ATM Card Internet Banking" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Jean", Value = "Đồ Jean" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "JobSupport", Value = "Job Support" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Jumpsuits", Value = "Jumpsuits" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Language", Value = "Language" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Like", Value = "Like" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Login", Value = "Login" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Logout", Value = "Logout" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "LowToHigh", Value = "Low to high" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Male", Value = "Male" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Money", Value = "$" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "NewArrival", Value = "New Arrival" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "NewCustomers", Value = "New Customers" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "News", Value = "News" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "NewTrend", Value = "News Trends" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Note", Value = "notes" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Order", Value = "Order" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "OrderCode", Value = "Order #" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "OrderStatus", Value = "Status" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Other", Value = "Other" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "PageOf", Value = "Page {0} of {1}" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Password", Value = "Password" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "PasswordLong", Value = "The {0} must be at least {2} characters long." });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Payment", Value = "Payment" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "PaymentMethod", Value = "Payment method" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "PaymentNext", Value = "Next" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "PaymentText", Value = "You will pay money once received product." });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "PaymentType", Value = "Payment type" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "PaymentWizard", Value = "Payment wizard" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "PhoneRequired", Value = "Phone is required" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "PriceList", Value = "Price list" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ProceedToCheckout", Value = "Proceed To Checkout" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Product", Value = "Product" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ProductDescription", Value = "Product Description" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ProductName", Value = "Product name" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ProductSize", Value = "SIZE" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Quan", Value = "Trousers & Shorts" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Quantity", Value = "Quick Delivery" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "QuestionAnwser", Value = "Question and answer" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "QuickDelivery", Value = "Quick Delivery" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ReceivedProductAndPayment", Value = "Received product and payment" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Register", Value = "Register" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "RegisteredCustomers", Value = "Registered Customers" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "RegisterNewUser", Value = "Register a new user" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "RegularManagement", Value = "Regular Management" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Reguleration", Value = "Reguleration" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "RememberMe", Value = "Remember me?" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Remove", Value = "Delete" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "RemoveOrder", Value = "Remove order item" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ReOrder", Value = "Continues shipping" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "RePassword", Value = "re-type Password" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "SaleCoperation", Value = "Sale Coperation" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "SaleOff", Value = "Sale off" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Search", Value = "Search" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "SelectDate", Value = "Select date" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "SelectShippingType", Value = "Select shipping type" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Send", Value = "Send email" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Share", Value = "Share" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ShippingAddress", Value = "Address" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ShippingAddressLong", Value = "Address is longer than 500 characters" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ShippingToAddressRequired", Value = "Enter address" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ShippingType", Value = "Shipping type" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ShipTo", Value = "Ship to" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ShoppingCard", Value = "Shopping Card" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ShoppingCart", Value = "Shopping Card" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ShoppingComment", Value = "Contend" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ShoppingPhone", Value = "Phone" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ShoppingPhoneLong", Value = "Phone is longer than 11 characters" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ShoppingPhoneRequired", Value = "Phone is required" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ShoppingReduceCode", Value = "Reduce code	" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ShoppingReduceCodeLong", Value = "Reduce is longer than 15 characters" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Shoses", Value = "Giày" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Size", Value = "Size" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Sku", Value = "Sku" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "SortBy", Value = "Sort by	" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "SpecialOffers", Value = "Registry to get special offers from YS ME Fashion" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Standard", Value = "Standard" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Subject", Value = "Subject" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "SubjectText", Value = "Subject" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "SubTotal", Value = "SubTotal" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Support", Value = "Support" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Tab", Value = "Tab" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "TextNewCustomers", Value = "By creating an account with our store, you will be able to move through the checkout process faster, store multiple shipping addresses, view and track your orders in your account and more." });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "TextRegisteredCustomers", Value = "Đăng nhập nếu bạn đã có tài khoản trong hệ thống	" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UnitPrice", Value = "Price" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UpdateAccount", Value = "Update" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UpdateShoppingCart", Value = "Update Cart" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UpdateUserError", Value = "Can not update the value" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UserAddress1", Value = "Address 1" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UserAddress1Required", Value = "Address is required" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UserAddress2", Value = "Address 2" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UserBirthday", Value = "Birthday" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UserEmail", Value = "Email" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UserImage", Value = "Image" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "Username", Value = "Username" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UsernameLong", Value = "Username is longer tha 50 characters" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UsernameRequired", Value = "Enter username" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UserPasswordRequired", Value = "Enter password" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UserPhone", Value = "Phone" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UserPhoneRequired", Value = "Phone is required" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UserRole", Value = "Role" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UsingCard", Value = "Using card" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UsingCash", Value = "Cash" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "VietName", Value = "Vietnam" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ViewDetailOrder", Value = "View product detail" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ViewOrder", Value = "View order" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "VisaMasterCard", Value = "Visa, Master card" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "WeGotYourEmail", Value = "We received your email !" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "WhatAreYouLookingFor", Value = "What are you looking for ?" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "WhatIsHot", Value = "Hot items" });
            //UserProfile
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "UserProfile", Value = "View user profile" });
            //ShoppingCommentLong
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ShoppingCommentLong", Value = "Comment is longer than 300 characters" });

            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GhnReadyToPick", Value = "Ready to pick" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GhnPicking", Value = "Picking" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GhnStoring", Value = "Storing" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GhnDelivering", Value = "Delivering" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GhnDelivered", Value = "Delivered" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GhnWaitingToFinish", Value = "Waiting to finish" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GhnFinish", Value = "Finish" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GhnReturn", Value = "Return" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GhnCancel", Value = "Cancel" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GhnSixHours", Value = "6 hours" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GhnOneday", Value = "1 day" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GhnTwoDay", Value = "2 days" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GhnThreeDay", Value = "3 days" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GhnFourDay", Value = "4 days" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "GhnFiveDay", Value = "5 days" });
            //OrderHistory
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "OrderHistory", Value = "View order history" });
            //ProvinceId
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ProvinceId", Value = "District/City" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "ProvinceIdRequired", Value = "Province is required" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "SelectProvince", Value = "Please select District/City" });
            context.Resources.Add(new Resource { CreatedDate = DateTime.Now, Culture = "en-US", Name = "PleaseSelect", Value = "Please select..." });
            #endregion

            context.SaveChanges();
        }

        public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<MainContext>
        {
            protected override void Seed(MainContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class CreateInitializer : CreateDatabaseIfNotExists<MainContext>
        {
            protected override void Seed(MainContext context)
            {
                context.Seed(context);

                base.Seed(context);
            }
        }

        static MainContext()
        {
            #if DEBUG
            Database.SetInitializer<MainContext>(new DropCreateIfChangeInitializer());
            #else
                    Database.SetInitializer<MainContext> (new CreateInitializer ());
            #endif
        }
    }
}
