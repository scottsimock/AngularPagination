using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AngularPagination.App_Start;

namespace AngularPagination
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
