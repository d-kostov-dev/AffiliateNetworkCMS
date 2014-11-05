namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using System;
    using System.Linq.Dynamic;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;
    using AffiliateNetwork.Web.Areas.Administration.Models;
    using AffiliateNetwork.Web.Infrastructure.Filters;
    
    
    public class CategoriesController : BaseController
    {
        private const int defaultPageSize =1;

        public CategoriesController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult IndexNew(string sortDirection = "ASC", int? page = 1, string sort = "Id")
        {
            // string sort = "Id", string sortDirection, int? page
            //var currentPage = page ?? 1;
            //ViewData["SortItem"] = sort;
            //sort = sort ?? "Id";
            //ViewData["CurrentPage"] = currentPage;
            //ViewData["TotalPages"] = (int)Math.Ceiling((float)this.Data.Categories.All().Count() / _pageSize);

            //var products = this.Data.Categories.All().Select(ListCategoryViewModel.ViewModel);

            //var sortedProducts = products
            //    .OrderBy(sort)
            //    .Skip((currentPage - 1) * _pageSize)
            //    .Take(_pageSize);

            var products = this.Data.Categories.All().Select(ListCategoryViewModel.ViewModel);
            return View(products);
        }

        public ActionResult Index(string sortBy, string sortDirection, string searchString, int? page)
        {
            sortBy = string.IsNullOrEmpty(sortBy) ? "Id" : sortBy;
            ViewBag.SortDirection = sortDirection == "ASC" ? "DESC" : "ASC";
            var currentPage = page ?? 1;
            ViewBag.CurrentPage = currentPage;
            ViewBag.TotalPages= (int)Math.Ceiling((float)this.Data.Categories.All().Count() / defaultPageSize);
            ViewBag.CurrentSort = sortBy;

            var selectedItems = this.Data.Categories.All();

            if (!String.IsNullOrEmpty(ViewBag.SearchString))
            {
                string searchVar = ViewBag.SearchString;
                selectedItems = selectedItems.Where(x => x.Name.ToLower().Contains(searchVar.ToLower()));
            }

            if (ViewBag.SortDirection == "DESC")
            {
                selectedItems = selectedItems.OrderBy(sortBy + " " + "descending");
            }
            else
            {
                selectedItems = selectedItems.OrderBy(sortBy);
            }

            selectedItems = selectedItems
                .Skip((currentPage - 1) * defaultPageSize)
                .Take(defaultPageSize);

            return View(selectedItems.ToList());
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
