using System.Web.Optimization;
using Microsoft.Ajax.Utilities;

namespace AngularPagination.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        // jquery
                        "~/Scripts/jquery-{version}.js",
                        
                        // angular
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-route.js",

                        // bootstrap
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/ui-bootstrap-0.7.0.js",
                        "~/Scripts/ui-bootstrap-tpls-0.7.0.js",
                        
                        // restangular
                        "~/Scripts/restangular.js",
                        "~/Scripts/lodash.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Scripts/lib/app.js",
                "~/Scripts/lib/api.js",
                "~/Scripts/lib/controller.js",
                "~/Scripts/lib/onBlurChange.js",
                "~/Scripts/lib/onEnterBlur.js",
                "~/Scripts/lib/sortBy.js"
            ));

            bundles.Add(new StyleBundle("~/styles/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css"
            ));

        }
    }
}