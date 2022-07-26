using System.Web;
using System.Web.Optimization;

namespace Project02CarRentalWebApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/calc").Include("~/Content/calculator.css"));
            bundles.Add(new ScriptBundle("~/bundles/surveys").Include("~/Scripts/survey.js"));
            bundles.Add(new ScriptBundle("~/bundles/apis").Include("~/Scripts/apiSample.js"));
            bundles.Add(new ScriptBundle("~/bundles/addresses").Include("~/Scripts/addresses.js"));
            bundles.Add(new ScriptBundle("~/bundles/calc").Include("~/Scripts/calculator.js"));
            bundles.Add(new ScriptBundle("~/bundles/myscripts").Include("~/Scripts/navbar.js", "~/Scripts/global.js"));
        }
    }
}
