using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinhShop.ActionAttribute
{
    public class RequireAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctx = HttpContext.Current;
            // Check if session is support
            if (WebCommon.SessionUserName == null || WebCommon.SessionPassword == null)
            {
                ctx.Response.Redirect("~/Admin/Login");
                base.OnActionExecuting(filterContext);
            }
            base.OnActionExecuting(filterContext);
        }

    }
}