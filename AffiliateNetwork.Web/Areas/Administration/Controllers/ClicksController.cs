namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Web.Areas.Administration.Controllers.Base;
    using AffiliateNetwork.Web.Areas.Administration.Models.ViewModels;

    using AutoMapper.QueryableExtensions;
    using AffiliateNewtork.Infrastructure;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class ClicksController : AdminBaseController
    {
        public ClicksController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult Index()
        {
            var clicks = 
                this.Data.Clicks.All()
                .Project()
                .To<ClicksListViewModels>();

            return View(clicks);
        }

        public ActionResult Delete(int id)
        {
            var click = this.Data.Clicks.Find(id);
            this.Data.Clicks.Delete(click);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
