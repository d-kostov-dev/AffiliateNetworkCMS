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

            // Administration Styles
            bundles.Add(new StyleBundle("~/Content/Administration/styles").Include(
                      "~/Areas/Administration/Content/css/bootstrap.css",
                      "~/Areas/Administration/Content/css/sb-admin-2.css",
                      "~/Areas/Administration/Content/css/metisMenu.css",
                      "~/Areas/Administration/Content/css/font-awesome.css"
                      ));

            // Administration Scripts
            bundles.Add(new ScriptBundle("~/Content/Administration/js").Include(
                     "~/Areas/Administration/Content/scripts/jquery.js",
                     "~/Areas/Administration/Content/scripts/bootstrap.js",
                     "~/Areas/Administration/Content/scripts/plugins/metisMenu/metisMenu.min.js",
                     "~/Areas/Administration/Content/scripts/sb-admin-2.js"
                     ));

            BundleTable.EnableOptimizations = true;
        }
    }
}
