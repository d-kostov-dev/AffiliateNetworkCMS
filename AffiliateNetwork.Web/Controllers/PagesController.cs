namespace AffiliateNetwork.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using AffiliateNetwork.Web.Models;

    using AutoMapper.QueryableExtensions;
    using AffiliateNetwork.Contracts;

    public class PagesController : BaseController
    {
        public PagesController(IDataProvider provider)
            : base(provider)
        {

        }

        public ActionResult Details(string pageSeoUrl)
        {
            var page = 
                this.Data.InfoPages.All()
                .Where(x => x.SeoUrl == pageSeoUrl)
                .Project().To<PageDetailsViewModel>()
                .FirstOrDefault();

            return View(page);
        }

        public ActionResult GetPages()
        {
            var pages = this.Data.InfoPages.All().Project().To<PagesFooterViewModel>();
            return this.PartialView("_PagesFooterPartial", pages);
        }
    }
}