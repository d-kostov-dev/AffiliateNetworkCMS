
namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;
    using AffiliateNetwork.Web.Areas.Administration.Models.ViewModels;
    using AffiliateNetwork.Web.Areas.Administration.Controllers.Base;
    using AffiliateNewtork.Infrastructure;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class InfoPagesController : AdminBaseController
    {
        public InfoPagesController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult Index()
        {
            this.ManagePageSizing();

            return View(this.Data.InfoPages.AllWithDeleted().Select(ListInfoPageViewModel.ViewModel).OrderBy(x => x.Id));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            InfoPage infoPage = this.Data.InfoPages.Find(id);

            if (infoPage == null)
            {
                return HttpNotFound();
            }

            return View(infoPage);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InfoPage infoPage)
        {
            if (ModelState.IsValid)
            {
                this.Data.InfoPages.Add(infoPage);
                this.Data.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(infoPage);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            InfoPage infoPage = this.Data.InfoPages.Find(id);

            if (infoPage == null)
            {
                return HttpNotFound();
            }

            return View(infoPage);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InfoPage infoPage)
        {
            if (ModelState.IsValid)
            {
                this.Data.InfoPages.Update(infoPage);
                this.Data.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(infoPage);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var infoPage = this.Data.InfoPages.Find(id);

            if (infoPage == null)
            {
                return HttpNotFound();
            }

            return View(infoPage);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InfoPage infoPage = this.Data.InfoPages.Find(id);
            this.Data.InfoPages.Delete(infoPage);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
