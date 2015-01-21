using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace dsiPDCXListener
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var config = new dsiPDCXListener.Infrastructure.ConfigHelper();

            Application["TranDeviceID"] = config.TranDeviceID;
            Application["PostURL"] = config.PostURL;
            Application["PostURLMethod"] = config.PostURLMethod;
            Application["ComPort"] = config.ComPort;
            Application["SecureDevice"] = config.SecureDevice;
            Application["MerchantID"] = config.MerchantID;
            Application["IncludeRecordNoAndFrequency"] = false;

        }
    }
}
