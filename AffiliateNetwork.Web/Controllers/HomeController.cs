namespace AffiliateNetwork.Web.Controllers
{
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;

    public class HomeController : BaseController
    {
        public HomeController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}