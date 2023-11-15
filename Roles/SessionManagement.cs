using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolyteksEnerjiYonetimSistemi.Roles
{
    public class SessionManagement
    {
  
    }
    public class SessionTimeoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext httpContext = HttpContext.Current;
            if (HttpContext.Current.Session["userId"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Giris");
                return;
            }
            base.OnActionExecuting(filterContext);

        }
    }
}