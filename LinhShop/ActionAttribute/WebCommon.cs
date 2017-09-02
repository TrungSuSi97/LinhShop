using LinhNguyen.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;

namespace LinhShop.ActionAttribute
{
    public class WebCommon
    {
        public static List<OrderModel> SessionOrderList
        {
            get
            {
                return HttpContext.Current.Session["OrderList"] as List<OrderModel>;
            }
            set
            {
                HttpContext.Current.Session["OrderList"] = value;
            }
        }

        public static string SessionUserId
        {
            get
            {
                return HttpContext.Current.Session["UserId"] as string;
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }

        public static string SessionAdmin
        {
            get
            {
                return HttpContext.Current.Session["Admin"] as string;
            }
            set
            {
                HttpContext.Current.Session["Admin"] = value;
            }
        }

        public static string SessionUserName
        {
            get
            {
                return HttpContext.Current.Session["UserName"] as string;
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }

        public static string SessionEmail
        {
            get
            {
                return HttpContext.Current.Session["Email"] as string;
            }
            set
            {
                HttpContext.Current.Session["Email"] = value;
            }
        }

        public static string SessionPassword
        {
            get
            {
                return HttpContext.Current.Session["Password"] as string;
            }
            set
            {
                HttpContext.Current.Session["Password"] = value;
            }
        }

        public static string SessionAddress
        {
            get
            {
                return HttpContext.Current.Session["Address"] as string;
            }
            set
            {
                HttpContext.Current.Session["Address"] = value;
            }
        }

        public static string SessionFullName
        {
            get
            {
                return HttpContext.Current.Session["FullName"] as string;
            }
            set
            {
                HttpContext.Current.Session["FullName"] = value;
            }
        }

        public static string SessionMenuActive
        {
            get
            {
                return HttpContext.Current.Session["MenuActiveId"] as string;
            }
            set
            {
                HttpContext.Current.Session["MenuActiveId"] = value;
            }
        }

        public static string SessionCurrentMoney
        {
            get
            {
                return HttpContext.Current.Session["CurrentMoney"] as string;
            } 
            set
            {
                HttpContext.Current.Session["CurrentMoney"] = value;
            }
        }

        public static string SessionStrHomeSearch
        {
            get
            {
                return HttpContext.Current.Session["StrHomeSearch"] as string;
            }
            set
            {
                HttpContext.Current.Session["StrHomeSearch"] = value;
            }
        }

        public static string GetIPAddress()
        {
            var macAddress =
                 (

                   from nic in NetworkInterface.GetAllNetworkInterfaces()
                   where nic.OperationalStatus == OperationalStatus.Up
                   select nic.GetPhysicalAddress().ToString()
                 ).FirstOrDefault();

            return macAddress;
        }
    }
}