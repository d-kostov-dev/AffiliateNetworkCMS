namespace AffiliateNetwork.Web.Controllers
{
    using System.Linq;
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

        public ActionResult About()
        {
            return this.Content(string.Join(", ", this.Data.InfoPages.All().Select(x => x.Title).ToList()));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}