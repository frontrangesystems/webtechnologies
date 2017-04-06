using System.Web.Optimization;

namespace FrontRangeSystems.WebTechnologies.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            var js = "*.js";

            bundles.Add(new ScriptBundle("~/Angular/1x").Include(
                    "~/scripts/angular.js",
                    "~/scripts/angular-route.js",
                    "~/scripts/angular-ui-router.js",
                    "~/scripts/angular-resource.js")
                .IncludeDirectory("~/app/angular1/services", js, true)
                .IncludeDirectory("~/app/angular1", js, false)
                .IncludeDirectory("~/app/angular1", js, true)
            );

//            bundles.Add(new ScriptBundle("~/Angular/2").Include(
//                "~/app/dist/inline.bundle.js",
//                "~/app/dist/polyfills.bundle.js",
//                "~/app/dist/styles.bundle.js",
//                "~/app/dist/vendor.bundle.js",
//                "~/app/dist/main.bundle.js"
//            ));
        }
    }
}
