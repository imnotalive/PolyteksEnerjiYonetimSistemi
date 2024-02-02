using PolyteksEnerjiYonetimSistemi.App_Start;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PolyteksEnerjiYonetimSistemi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            CultureInfo cultureInfo = new CultureInfo("tr-TR");

            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
            CultureInfo.CurrentCulture = cultureInfo;
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("tr-TR");
        }
        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)

        {
            filters.Add(new System.Web.Mvc.AuthorizeAttribute());
        }
  
    }
}
