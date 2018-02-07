using System.Web;
using System.Web.Optimization;

namespace AngularMvcWeb.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/thirdparty").Include(
               "~/Scripts/ui-bootstrap-tpls.js",
                "~/Scripts/angular-block-ui/angular-block-ui.min.js",
                "~/Scripts/ui-sortable-0.17.1/sortable.min.js"
             ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css"));
        }
    }
}