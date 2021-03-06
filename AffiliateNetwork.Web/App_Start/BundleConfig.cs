﻿namespace AffiliateNetwork.Web
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            RegisterScriptBundles(bundles);
            RegisterStylesBundles(bundles);

            BundleTable.EnableOptimizations = true;
        }

        private static void RegisterStylesBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Site/css/bootstrap.css",
                      "~/Content/Site/css/site.css"));

            bundles.Add(new StyleBundle("~/Content/Manager/styles").Include(
                      "~/Content/Manager/css/bootstrap.css",
                      "~/Content/Manager/css/sb-admin-2.css",
                      "~/Content/Manager/css/metisMenu.css",
                      "~/Content/Manager/css/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/Manager/css/Kendo/Styles").Include(
                      "~/Content/Manager/css/Kendo/kendo.common.min.css",
                      "~/Content/Manager/css/Kendo/kendo.bootstrap.min.css",
                      "~/Content/Manager/css/Kendo/kendo.default.min.css"));
        }

        private static void RegisterScriptBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusive")
                .Include("~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/Content/Manager/js").Include(
                     "~/Scripts/Kendo/jquery.min.js",
                     "~/Content/Manager/scripts/bootstrap.js",
                     "~/Content/Manager/scripts/plugins/metisMenu/metisMenu.min.js",
                     "~/Content/Manager/scripts/sb-admin-2.js",
                     "~/Scripts/Kendo/kendo.all.min.js",
                     "~/Scripts/Kendo/kendo.aspnetmvc.min.js"));
        }
    }
}
