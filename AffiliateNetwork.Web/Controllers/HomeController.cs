namespace AffiliateNetwork.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;

    public class HomeController : Controller
    {
        private IDataProvider data;

        public HomeController(IDataProvider data)
        {
            this.data = data;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            return this.Content(string.Join(", ", this.data.InfoPages.All().Select(x => x.Title).ToList()));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}