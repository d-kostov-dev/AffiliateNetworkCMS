namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Web.Areas.Administration.Controllers.Base;
    
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