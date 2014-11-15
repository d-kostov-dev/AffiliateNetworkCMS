namespace AffiliateNetwork.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "InfoPages",
                url: "{pageSeoUrl}",
                defaults: new { controller = "Pages", action = "Details" },
                namespaces: new[] { "AffiliateNetwork.Web.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "AffiliateNetwork.Web.Controllers" });
        }
    }
}
