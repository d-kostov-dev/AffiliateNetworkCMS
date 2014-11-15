namespace AffiliateNetwork.Web
{
    using System.Web.Mvc;

    public class ViewEnginesConfig
    {
        internal static void RegisterViewEngines(ViewEngineCollection engines)
        {
            engines.Clear();
            engines.Add(new RazorViewEngine());
        }
    }
}