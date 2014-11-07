namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using AffiliateNetwork.Contracts;
    
    public class DashboardController : AdminBaseController
    {
        public DashboardController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}