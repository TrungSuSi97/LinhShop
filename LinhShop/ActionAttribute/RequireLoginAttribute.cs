using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinhShop.ActionAttribute
{
    public class RequireLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctx = HttpContext.Current;
            if (WebCommon.SessionUserName == null || WebCommon.SessionUserId == null)
            {
                ctx.Response.Redirect("~/Account/Login");
                base.OnActionExecuting(filterContext);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}