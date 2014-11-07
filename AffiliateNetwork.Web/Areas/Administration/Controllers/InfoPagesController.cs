
namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;
    using AffiliateNetwork.Web.Areas.Administration.Models;
    
    public class InfoPagesController : BaseController
    {
        private const int defaultPageSize = 1;

        public InfoPagesController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult Index()
        {
            int pagesize;

            if (!int.TryParse(Request.QueryString["perPage"], out pagesize))
            {
                pagesize = defaultPageSize;
            }
                
            ViewBag.PageSize = pagesize;

            return View(this.Data.InfoPages.All().Select(ListInfoPageViewModel.ViewModel).OrderBy(x => x.Id));
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
        public ActionResult Create([Bind(Include = "Id,SeoUrl,Title,Content,Order,IsVisible")] InfoPage infoPage)
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
        public ActionResult Edit([Bind(Include = "Id,SeoUrl,Title,Content,Order,IsVisible")] InfoPage infoPage)
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

            InfoPage infoPage = this.Data.InfoPages.Find(id);

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
