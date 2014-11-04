namespace AffiliateNetwork.Web
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Manager/styles").Include(
                      "~/Content/Manager/css/bootstrap.css",
                      "~/Content/Manager/css/sb-admin-2.css",
                      "~/Content/Manager/css/metisMenu.css",
                      "~/Content/Manager/css/font-awesome.css"
                      ));

            bundles.Add(new ScriptBundle("~/Content/Manager/js").Include(
                     "~/Content/Manager/scripts/jquery.js",
                     "~/Content/Manager/scripts/bootstrap.js",
                     "~/Content/Manager/scripts/plugins/metisMenu/metisMenu.min.js",
                     "~/Content/Manager/scripts/sb-admin-2.js"
                     ));

            BundleTable.EnableOptimizations = true;
        }
    }
}
