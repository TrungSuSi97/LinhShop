using LinhNguyen.Resources.Abstract;
using LinhNguyen.Resources.Concrete;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Resources
{
    public class Resources
    {
        private static IResourceProvider resourceProvider = new DbResourceProvider(); //  new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Resources.xml"));

        #region Index
        public static string MenuHone
        {
            get
            {
                return resourceProvider.GetResource("Home", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string MenuDress
        {
            get
            {
                return resourceProvider.GetResource("Dress", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string MenuJumpsuits
        {
            get
            {
                return resourceProvider.GetResource("Jumpsuits", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string MenuChanVay
        {
            get
            {
                return resourceProvider.GetResource("ChanVay", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string MenuQuan
        {
            get
            {
                return resourceProvider.GetResource("Quan", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string MenuAo
        {
            get
            {
                return resourceProvider.GetResource("Ao", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string MenuBoSuuTap
        {
            get
            {
                return resourceProvider.GetResource("BosuuTap", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtLogin
        {
            get
            {
                return resourceProvider.GetResource("Login", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtLogout
        {
            get
            {
                return resourceProvider.GetResource("Logout", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtHello
        {
            get
            {
                return resourceProvider.GetResource("Hello", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtSearch
        {
            get
            {
                return resourceProvider.GetResource("Search", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtRegister
        {
            get
            {
                return resourceProvider.GetResource("Register", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtHotLine
        {
            get
            {
                return resourceProvider.GetResource("HotLine", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtShoppingCard
        {
            get
            {
                return resourceProvider.GetResource("ShoppingCard", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtHotDeals
        {
            get
            {
                return resourceProvider.GetResource("HotDeals", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtNewTrend
        {
            get
            {
                return resourceProvider.GetResource("NewTrend", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtSaleOff//TxtAddToCart
        {
            get
            {
                return resourceProvider.GetResource("SaleOff", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtAddToCart
        {
            get
            {
                return resourceProvider.GetResource("AddToCart", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtBosuuTap
        {
            get
            {
                return resourceProvider.GetResource("BosuuTap", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtNews
        {
            get
            {
                return resourceProvider.GetResource("News", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtMoney
        {
            get
            {
                return resourceProvider.GetResource("Money", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtSend
        {
            get
            {
                return resourceProvider.GetResource("Send", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtEnterEmail
        {
            get
            {
                return resourceProvider.GetResource("EnterEmail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtWeGotYourEmail
        {
            get
            {
                return resourceProvider.GetResource("WeGotYourEmail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtEmailExisting
        {
            get
            {
                return resourceProvider.GetResource("EmailExisting", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtErrorOccurHere
        {
            get
            {
                return resourceProvider.GetResource("ErrorOccurHere", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtContactInformation
        {
            get
            {
                return resourceProvider.GetResource("ContactInformation", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtConditionChangeProduct
        {
            get
            {
                return resourceProvider.GetResource("ConditionChangeProduct", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtFreeChangeAfter30Day
        {
            get
            {
                return resourceProvider.GetResource("FreeChangeAfter30Day", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtFreeDelivery
        {
            get
            {
                return resourceProvider.GetResource("FreeDelivery", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtCustomerSupport
        {
            get
            {
                return resourceProvider.GetResource("CustomerSupport", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtQuestionAnwser
        {
            get
            {
                return resourceProvider.GetResource("QuestionAnwser", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtContact
        {
            get
            {
                return resourceProvider.GetResource("Contact", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtPriceList
        {
            get
            {
                return resourceProvider.GetResource("PriceList", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtGift
        {
            get
            {
                return resourceProvider.GetResource("Gift", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtCheckOrder
        {
            get
            {
                return resourceProvider.GetResource("CheckOrder", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtAboutUs
        {
            get
            {
                return resourceProvider.GetResource("AboutUs", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtAboutYsme
        {
            get
            {
                return resourceProvider.GetResource("AboutYsme", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtJobSupport
        {
            get
            {
                return resourceProvider.GetResource("JobSupport", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtSaleCoperation
        {
            get
            {
                return resourceProvider.GetResource("SaleCoperation", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtCondition
        {
            get
            {
                return resourceProvider.GetResource("Condition", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtRegularManagement
        {
            get
            {
                return resourceProvider.GetResource("RegularManagement", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtReceivedProductAndPayment
        {
            get
            {
                return resourceProvider.GetResource("ReceivedProductAndPayment", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtConnectFacebook
        {
            get
            {
                return resourceProvider.GetResource("ConnectFacebook", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtDeliveryService
        {
            get
            {
                return resourceProvider.GetResource("DeliveryService", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtPaymentMethod
        {
            get
            {
                return resourceProvider.GetResource("PaymentMethod", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtIdentity
        {
            get
            {
                return resourceProvider.GetResource("Identity", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtEmailAddress
        {
            get
            {
                return resourceProvider.GetResource("EmailAddress", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        #endregion

        #region ShopDetail
        public static string TxtImage
        {
            get
            {
                return resourceProvider.GetResource("Image", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtProductName
        {
            get
            {
                return resourceProvider.GetResource("ProductName", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtUnitPrice
        {
            get
            {
                return resourceProvider.GetResource("UnitPrice", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtQuantity
        {
            get
            {
                return resourceProvider.GetResource("Quantity", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtSize
        {
            get
            {
                return resourceProvider.GetResource("Size", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtColor
        {
            get
            {
                return resourceProvider.GetResource("Color", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtSubTotal
        {
            get
            {
                return resourceProvider.GetResource("SubTotal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtRemove
        {
            get
            {
                return resourceProvider.GetResource("Remove", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtViewDetailOrder
        {
            get
            {
                return resourceProvider.GetResource("ViewDetailOrder", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtRemoveOrder
        {
            get
            {
                return resourceProvider.GetResource("RemoveOrder", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtAddOrder
        {
            get
            {
                return resourceProvider.GetResource("AddOrder", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtContinueShopping
        {
            get
            {
                return resourceProvider.GetResource("ContinueShopping", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtClearShoppingCart
        {
            get
            {
                return resourceProvider.GetResource("ClearShoppingCart", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtContactUs
        {
            get
            {
                return resourceProvider.GetResource("ContactUs", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtContactString
        {
            get
            {
                return resourceProvider.GetResource("ContactString", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtDiscountText
        {
            get
            {
                return resourceProvider.GetResource("DiscountText", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtGrandTotal
        {
            get
            {
                return resourceProvider.GetResource("GrandTotal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtPaymentText
        {
            get
            {
                return resourceProvider.GetResource("PaymentText", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtBestSeller
        {
            get
            {
                return resourceProvider.GetResource("BestSeller", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtAnotherNews
        {
            get
            {
                return resourceProvider.GetResource("AnotherNews", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtProductCode
        {
            get
            {
                return resourceProvider.GetResource("ProductCode", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtCreatedDate
        {
            get
            {
                return resourceProvider.GetResource("CreatedDate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtProductSize
        {
            get
            {
                return resourceProvider.GetResource("ProductSize", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtNote
        {
            get
            {
                return resourceProvider.GetResource("Note", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtChoseIt
        {
            get
            {
                return resourceProvider.GetResource("ChoseIt", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtShare
        {
            get
            {
                return resourceProvider.GetResource("Share", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtCategories
        {
            get
            {
                return resourceProvider.GetResource("Categories", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtTab
        {
            get
            {
                return resourceProvider.GetResource("Tab", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtProductDescription
        {
            get
            {
                return resourceProvider.GetResource("ProductDescription", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtAdditionalInformation
        {
            get
            {
                return resourceProvider.GetResource("AdditionalInformation", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtClothing
        {
            get
            {
                return resourceProvider.GetResource("Clothing", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtLike
        {
            get
            {
                return resourceProvider.GetResource("Like", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtSortBy
        {
            get
            {
                return resourceProvider.GetResource("SortBy", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtLowToHigh
        {
            get
            {
                return resourceProvider.GetResource("LowToHigh", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtHighToLow
        {
            get
            {
                return resourceProvider.GetResource("HighToLow", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtPaymentWizard
        {
            get
            {
                return resourceProvider.GetResource("PaymentWizard", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtChosePaymentMethod
        {
            get
            {
                return resourceProvider.GetResource("ChosePaymentMethod", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtChoseShipMethod
        {
            get
            {
                return resourceProvider.GetResource("ChoseShipMethod", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtInputAddress
        {
            get
            {
                return resourceProvider.GetResource("InputAddress", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtUsingCash
        {
            get
            {
                return resourceProvider.GetResource("UsingCash", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtInternertBanking
        {
            get
            {
                return resourceProvider.GetResource("InternertBanking", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtEnterReduceCode
        {
            get
            {
                return resourceProvider.GetResource("EnterReduceCode", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtPaymentNext
        {
            get
            {
                return resourceProvider.GetResource("PaymentNext", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtQuickDelivery
        {
            get
            {
                return resourceProvider.GetResource("QuickDelivery", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtStandard
        {
            get
            {
                return resourceProvider.GetResource("Standard", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtEnterFullName
        {
            get
            {
                return resourceProvider.GetResource("EnterFullName", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtEnterPhoneNumber
        {
            get
            {
                return resourceProvider.GetResource("EnterPhoneNumber", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtEnterShippingAddress
        {
            get
            {
                return resourceProvider.GetResource("EnterShippingAddress", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtEnterComment
        {
            get
            {
                return resourceProvider.GetResource("EnterComment", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtPayment
        {
            get
            {
                return resourceProvider.GetResource("Payment", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtRegisteredCustomers
        {
            get
            {
                return resourceProvider.GetResource("RegisteredCustomers", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtTextRegisteredCustomers
        {
            get
            {
                return resourceProvider.GetResource("TextRegisteredCustomers", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtRegisterNewUser
        {
            get
            {
                return resourceProvider.GetResource("RegisterNewUser", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtForgotYourPassword
        {
            get
            {
                return resourceProvider.GetResource("ForgotYourPassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtNewCustomers
        {
            get
            {
                return resourceProvider.GetResource("NewCustomers", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtTextNewCustomers
        {
            get
            {
                return resourceProvider.GetResource("TextNewCustomers", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtFemale
        {
            get
            {
                return resourceProvider.GetResource("Female", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtMale
        {
            get
            {
                return resourceProvider.GetResource("Male", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtOther
        {
            get
            {
                return resourceProvider.GetResource("Other", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtSelectDate
        {
            get
            {
                return resourceProvider.GetResource("SelectDate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtCreateAnAcount
        {
            get
            {
                return resourceProvider.GetResource("CreateAnAcount", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtDaGiaoHang
        {
            get
            {
                return resourceProvider.GetResource("DaGiaoHang", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtDangGiaoHang
        {
            get
            {
                return resourceProvider.GetResource("DangGiaoHang", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtOrderCode
        {
            get
            {
                return resourceProvider.GetResource("OrderCode", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtOrderStatus
        {
            get
            {
                return resourceProvider.GetResource("OrderStatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtViewOrder
        {
            get
            {
                return resourceProvider.GetResource("ViewOrder", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtReOrder//EmailOrUsername
        {
            get
            {
                return resourceProvider.GetResource("ReOrder", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtEmailOrUsername
        {
            get
            {
                return resourceProvider.GetResource("EmailOrUsername", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtPassword
        {
            get
            {
                return resourceProvider.GetResource("Password", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtRememberMe
        {
            get
            {
                return resourceProvider.GetResource("RememberMe", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtEmailRequired
        {
            get
            {
                return resourceProvider.GetResource("EmailRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtUserPasswordRequired
        {
            get
            {
                return resourceProvider.GetResource("UserPasswordRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtFullNameRequired
        {
            get
            {
                return resourceProvider.GetResource("FullNameRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtFullNameLong
        {
            get
            {
                return resourceProvider.GetResource("FullNameLong", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtFullName
        {
            get
            {
                return resourceProvider.GetResource("FullName", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtUserEmail
        {
            get
            {
                return resourceProvider.GetResource("UserEmail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtEmailInvalid
        {
            get
            {
                return resourceProvider.GetResource("EmailInvalid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtEmailLong
        {
            get
            {
                return resourceProvider.GetResource("EmailLong", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /////////////////////

        public static string TxtUsernameRequired
        {
            get
            {
                return resourceProvider.GetResource("UsernameRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtUsernameLong
        {
            get
            {
                return resourceProvider.GetResource("UsernameLong", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtUsername
        {
            get
            {
                return resourceProvider.GetResource("Username", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtPasswordLong
        {
            get
            {
                return resourceProvider.GetResource("PasswordLong", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        //////////////////////////////////
        public static string TxtConfirmPassword
        {
            get
            {
                return resourceProvider.GetResource("ConfirmPassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtUserAddress1
        {
            get
            {
                return resourceProvider.GetResource("UserAddress1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtUserAddress2
        {
            get
            {
                return resourceProvider.GetResource("UserAddress2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtAddressRequired
        {
            get
            {
                return resourceProvider.GetResource("AddressRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtAddressLong
        {
            get
            {
                return resourceProvider.GetResource("AddressLong", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtUserPhone
        {
            get
            {
                return resourceProvider.GetResource("UserPhone", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtPhoneRequired
        {
            get
            {
                return resourceProvider.GetResource("PhoneRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtUserBirthday
        {
            get
            {
                return resourceProvider.GetResource("UserBirthday", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtUserRole
        {
            get
            {
                return resourceProvider.GetResource("UserRole", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtUserImage
        {
            get
            {
                return resourceProvider.GetResource("UserImage", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtSex
        {
            get
            {
                return resourceProvider.GetResource("Sex", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        //////////////////////////////

        public static string TxtSubjectText
        {
            get
            {
                return resourceProvider.GetResource("SubjectText", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtPaymentType
        {
            get
            {
                return resourceProvider.GetResource("PaymentType", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtShippingType
        {
            get
            {
                return resourceProvider.GetResource("ShippingType", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtShippingAddress
        {
            get
            {
                return resourceProvider.GetResource("ShippingAddress", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtShippingToAddressRequired
        {
            get
            {
                return resourceProvider.GetResource("ShippingToAddressRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtShippingAddressLong
        {
            get
            {
                return resourceProvider.GetResource("ShippingAddressLong", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtShoppingPhone
        {
            get
            {
                return resourceProvider.GetResource("ShoppingPhone", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtShoppingPhoneRequired
        {
            get
            {
                return resourceProvider.GetResource("ShoppingPhoneRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtShoppingPhoneLong
        {
            get
            {
                return resourceProvider.GetResource("ShoppingPhoneLong", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtShoppingComment
        {
            get
            {
                return resourceProvider.GetResource("ShoppingComment", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        /// <summary>
        /// //////////////////////
        /// </summary>
        public static string TxtShoppingCommentLong
        {
            get
            {
                return resourceProvider.GetResource("ShoppingCommentLong", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtShoppingReduceCode
        {
            get
            {
                return resourceProvider.GetResource("ShoppingReduceCode", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtShoppingReduceCodeLong
        {
            get
            {
                return resourceProvider.GetResource("ShoppingReduceCodeLong", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtUpdateAccount
        {
            get
            {
                return resourceProvider.GetResource("UpdateAccount", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtShipTo
        {
            get
            {
                return resourceProvider.GetResource("ShipTo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtUpdateUserError//TxtUpdateUserOk
        {
            get
            {
                return resourceProvider.GetResource("UpdateUserError", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtUpdateUserOk
        {
            get
            {
                return resourceProvider.GetResource("UpdateUserOk", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtContactSendOK
        {
            get
            {
                return resourceProvider.GetResource("ContactSendOK", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtContactError
        {
            get
            {
                return resourceProvider.GetResource("ContactError", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtUserProfile
        {
            get
            {
                return resourceProvider.GetResource("UserProfile", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtOrderHistory
        {
            get
            {
                return resourceProvider.GetResource("OrderHistory", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        #endregion

        #region Ghn Status
        public static string GhnReadyToPick
        {
            get
            {
                return resourceProvider.GetResource("GhnReadyToPick", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string GhnPicking
        {
            get
            {
                return resourceProvider.GetResource("GhnPicking", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string GhnStoring
        {
            get
            {
                return resourceProvider.GetResource("GhnStoring", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string GhnDelivering
        {
            get
            {
                return resourceProvider.GetResource("GhnDelivering", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string GhnDelivered
        {
            get
            {
                return resourceProvider.GetResource("GhnDelivered", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string GhnWaitingToFinish
        {
            get
            {
                return resourceProvider.GetResource("GhnWaitingToFinish", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string GhnFinish
        {
            get
            {
                return resourceProvider.GetResource("GhnFinish", CultureInfo.CurrentUICulture.Name) as String;
            }

        }

        public static string GhnReturn
        {
            get
            {
                return resourceProvider.GetResource("GhnReturn", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string GhnCancel
        {
            get
            {
                return resourceProvider.GetResource("GhnCancel", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string GhnSixHours
        {
            get
            {
                return resourceProvider.GetResource("GhnSixHours", CultureInfo.CurrentUICulture.Name) as String;
            }
        }



        public static string GhnTwoDay
        {
            get
            {
                return resourceProvider.GetResource("GhnTwoDay", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string GhnOneday
        {
            get
            {
                return resourceProvider.GetResource("GhnOneday", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string GhnThreeDay
        {
            get
            {
                return resourceProvider.GetResource("GhnThreeDay", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string GhnFourDay
        {
            get
            {
                return resourceProvider.GetResource("GhnFourDay", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string GhnFiveDay
        {
            get
            {
                return resourceProvider.GetResource("GhnFiveDay", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string GhnSupper
        {
            get
            {
                return resourceProvider.GetResource("GhnSupper", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string GhnSaving
        {
            get
            {
                return resourceProvider.GetResource("GhnSaving", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string GhnPrime
        {
            get
            {
                return resourceProvider.GetResource("GhnPrime", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string GhnFourHours
        {
            get
            {
                return resourceProvider.GetResource("GhnFourHours", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string GhnSixDay
        {
            get
            {
                return resourceProvider.GetResource("GhnSixDay", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string GhnSixtyMinute
        {
            get
            {
                return resourceProvider.GetResource("GhnSixtyMinute", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string GhnPerson
        {
            get
            {
                return resourceProvider.GetResource("GhnPerson", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string Ghn226
        {
            get
            {
                return resourceProvider.GetResource("Ghn226", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string GhnCollect
        {
            get
            {
                return resourceProvider.GetResource("GhnCollect", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtProvinceId
        {
            get
            {
                return resourceProvider.GetResource("ProvinceId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtProvinceIdRequired
        {
            get
            {
                return resourceProvider.GetResource("ProvinceIdRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtSelectProvince
        {
            get
            {
                return resourceProvider.GetResource("SelectProvince", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtPleaseSelect
        {
            get
            {
                return resourceProvider.GetResource("PleaseSelect", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtBeige
        {
            get
            {
                return resourceProvider.GetResource("Beige", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtBlack
        {
            get
            {
                return resourceProvider.GetResource("Black", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtBlue
        {
            get
            {
                return resourceProvider.GetResource("Blue", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtBrown
        {
            get
            {
                return resourceProvider.GetResource("Brown", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtGold
        {
            get
            {
                return resourceProvider.GetResource("Gold", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtGreen
        {
            get
            {
                return resourceProvider.GetResource("Green", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtGrey
        {
            get
            {
                return resourceProvider.GetResource("Grey", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtMulti
        {
            get
            {
                return resourceProvider.GetResource("Multi", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtNavy
        {
            get
            {
                return resourceProvider.GetResource("Navy", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtOrange
        {
            get
            {
                return resourceProvider.GetResource("Orange", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtPink
        {
            get
            {
                return resourceProvider.GetResource("Pink", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtPurple
        {
            get
            {
                return resourceProvider.GetResource("Purple", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtRed
        {
            get
            {
                return resourceProvider.GetResource("Red", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtSilver
        {
            get
            {
                return resourceProvider.GetResource("Silver", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtWhite
        {
            get
            {
                return resourceProvider.GetResource("White", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtYellow
        {
            get
            {
                return resourceProvider.GetResource("Yellow", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        /*Delivery hours*/

        public static string TxtDeliveryHours
        {
            get
            {
                return resourceProvider.GetResource("DeliveryHours", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtDeliveryDays
        {
            get
            {
                return resourceProvider.GetResource("DeliveryDays", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtPaymentMethodText
        {
            get
            {
                return resourceProvider.GetResource("PaymentMethodText", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtPaymentInternetText
        {
            get
            {
                return resourceProvider.GetResource("PaymentInternetText", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtYouHaveNoOrder
        {
            get
            {
                return resourceProvider.GetResource("YouHaveNoOrder", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtResetYourPassword
        {
            get
            {
                return resourceProvider.GetResource("ResetYourPassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtUpdatePassword
        {
            get
            {
                return resourceProvider.GetResource("UpdatePassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtPlsSelectColor
        {
            get
            {
                return resourceProvider.GetResource("PlsSelectColor", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtPlsSelectSize
        {
            get
            {
                return resourceProvider.GetResource("PlsSelectSize", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtDeliveryMessage
        {
            get
            {
                return resourceProvider.GetResource("DeliveryMessage", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtDeliveryTksMessage
        {
            get
            {
                return resourceProvider.GetResource("DeliveryTksMessage", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtOrderInfo
        {
            get
            {
                return resourceProvider.GetResource("OrderInfo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtPaymentInfo
        {
            get
            {
                return resourceProvider.GetResource("PaymentInfo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtDeliveryAddress
        {
            get
            {
                return resourceProvider.GetResource("DeliveryAddress", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtDeliveryPlan
        {
            get
            {
                return resourceProvider.GetResource("DeliveryPlan", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtDeliveryFee
        {
            get
            {
                return resourceProvider.GetResource("DeliveryFee", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtOrderDetail
        {
            get
            {
                return resourceProvider.GetResource("OrderDetail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtTongSpChuaGiamGia
        {
            get
            {
                return resourceProvider.GetResource("TongSpChuaGiamGia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtPointUsed
        {
            get
            {
                return resourceProvider.GetResource("PointUsed", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtTongSpSauGiamGia
        {
            get
            {
                return resourceProvider.GetResource("TongSpSauGiamGia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtSoLuong
        {
            get
            {
                return resourceProvider.GetResource("SoLuong", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtTongTam
        {
            get
            {
                return resourceProvider.GetResource("TongTam", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtConcernAboutOrder
        {
            get
            {
                return resourceProvider.GetResource("ConcernAboutOrder", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtCommonQuestion
        {
            get
            {
                return resourceProvider.GetResource("CommonQuestion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtOrderContact
        {
            get
            {
                return resourceProvider.GetResource("OrderContact", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtImmediateAssistance
        {
            get
            {
                return resourceProvider.GetResource("ImmediateAssistance", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtEmailImmediateAssistance
        {
            get
            {
                return resourceProvider.GetResource("EmailImmediateAssistance", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string TxtEndOrderInfo
        {
            get
            {
                return resourceProvider.GetResource("EndOrderInfo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtPoint
        {
            get
            {
                return resourceProvider.GetResource("Point", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string TxtDayMonthYear
        {
            get
            {
                return resourceProvider.GetResource("DayMonthYear", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtFinalEmailText
        {
            get
            {
                return resourceProvider.GetResource("FinalEmailText", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string TxtFinalEmailTextAddress
        {
            get
            {
                return resourceProvider.GetResource("FinalEmailTextAddress", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        #endregion
    }
}
