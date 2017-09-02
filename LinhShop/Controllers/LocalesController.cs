using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insya.Localization;

namespace LinhShop.Controllers
{
    public class LocalesController : Controller
    {
        // GET: Locales
        public ActionResult Index(string lang = "en_US")
        {
            Response.Cookies["CacheLang"].Value = lang;
            if (Request.UrlReferrer != null)
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            var message = Localization.Get("changedlng");
            return Content(message);
        }
    }
}