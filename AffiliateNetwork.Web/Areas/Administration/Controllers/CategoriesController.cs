namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;
    using System;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Net;
    using System.Web.Mvc;
    using AffiliateNetwork.Web.Areas.Administration.Models;
    using PagedList;


    public class CategoriesController : BaseController
    {
        private const int defaultPageSize =1;

        public CategoriesController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult Index(string searchFilter, int? page, string currentFilter, string sorting = "Id")
        {
            ViewBag.CurrentSort = sorting;

            ViewBag.IdSort = sorting == "Id" ? "Id descending" : "Id";
            ViewBag.NameSort = sorting == "Name" ? "Name descending" : "Name";
            ViewBag.CountSort = sorting == "CampaignsCount" ? "CampaignsCount descending" : "CampaignsCount";

            if (searchFilter != null)
            {
                page = 1;
            }
            else
            {
                searchFilter = currentFilter;
            }

            ViewBag.SearchFilter = searchFilter;

            var selectedItems = this.Data.Categories.All();

            if (!String.IsNullOrEmpty(searchFilter))
            {
                selectedItems = selectedItems
                    .Where(x => x.Name.ToLower().Contains(searchFilter.ToLower()));
            }

            var sortedItems = selectedItems
                .Select(ListCategoryViewModel.ViewModel)
                .OrderBy(sorting);

            int pageSize = 1;
            int pageNumber = (page ?? 1);

            return View(sortedItems.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                this.Data.Categories.Add(category);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = this.Data.Categories.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                this.Data.Categories.Update(category);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = this.Data.Categories.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = this.Data.Categories.Find(id);

            this.Data.Categories.Delete(category);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
