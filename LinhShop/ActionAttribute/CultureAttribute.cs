using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace LinhShop.ActionAttribute
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CultureAttribute : ActionFilterAttribute
    {
        private const String CookieLangEntry = "language";

        public String Name { get; set; }

        public static String CookieName
        {
            get
            {
                return "_Culture";
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var culture = Name;
            if (string.IsNullOrEmpty(culture))
            {
                culture = GetSavedCultureOrDefault(filterContext.RequestContext.HttpContext.Request);
            }

            // Set culture on current thread
            SetCultureOnThread(culture);

            // Proceed as usual
            base.OnActionExecuted(filterContext);
        }

        public static void SavePreferredCulture(HttpResponseBase response, String language, Int32 expireDay = 1)
        {
            var cookie = new HttpCookie(CookieName)
            {
                Expires = DateTime.Now.AddDays(expireDay)
            };
            cookie.Values[CookieLangEntry] = language;
            response.Cookies.Add(cookie);
        }

        public static String GetSavedCultureOrDefault(HttpRequestBase httpRequestBase)
        {
            var culture = "";
            var cookie = httpRequestBase.Cookies[CookieName];
            if (cookie != null)
            {
                culture = cookie.Values[CookieLangEntry];
            }       
            return culture;
        }

        private static void SetCultureOnThread(String language)
        {
            var cultureInfo = CultureInfo.CreateSpecificCulture(language);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
    }
}