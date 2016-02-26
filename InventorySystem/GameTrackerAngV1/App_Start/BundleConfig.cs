using System.Web.Optimization;

namespace GameTrackerAngV1.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

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

            bundles.Add(new StyleBundle("~/bundles/mini-spa/style").Include(
                       "~/Content/ng-grid.css"));
           
            //todo: break this into multiple bundles based on category, videogame etc
            bundles.Add(new ScriptBundle("~/bundles/mini-spa/script").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                "~/Scripts/ng-grid.js",
                "~/app/app.js",
                "~/app/dataService.js",
                "~/app/cacheService.js",
                "~/app/validationDirective.js",
                "~/app/Home/mainController.js",
                "~/app/Category/modalAddEditCategoryController.js",
                "~/app/Category/modalDeleteCategoryController.js",
                "~/app/Category/categoryController.js",
                "~/app/Budget/budgetController.js",
                "~/app/Tracking/trackingController.js",
                "~/app/VideoGame/videoGameController.js",
                 "~/app/VideoGame/videoGameAddEditController.js",
                "~/app/BoardGame/boardGameController.js",
               
                "~/app/Game/deleteGameController.js",
                "~/app/Schedule/scheduleController.js"));
        }
    }
}
