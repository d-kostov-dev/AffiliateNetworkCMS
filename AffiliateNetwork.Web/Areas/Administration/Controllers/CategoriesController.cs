﻿namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Net;
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;
    using AffiliateNetwork.Web.Areas.Administration.Controllers.Base;
    using AffiliateNetwork.Web.Areas.Administration.Models.InputModels;
    using AffiliateNetwork.Web.Areas.Administration.Models.ViewModels;
    using AffiliateNewtork.Common;

    using PagedList;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class CategoriesController : AdminBaseController
    {
        public CategoriesController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult Index(GridOptionsInputModel filter)
        {
            ViewBag.PerPage = filter.PerPage;
            ViewBag.CurrentSort = filter.Sorting;
            ViewBag.CurrentPage = filter.Page;

            ViewBag.IdSort = filter.Sorting == "Id" ? "Id descending" : "Id";
            ViewBag.NameSort = filter.Sorting == "Name" ? "Name descending" : "Name";
            ViewBag.CountSort = filter.Sorting == "CampaignsCount" ? "CampaignsCount descending" : "CampaignsCount";

            if (filter.SearchFilter != null)
            {
                filter.Page = 1;
            }
            else
            {
                filter.SearchFilter = filter.CurrentFilter;
            }

            ViewBag.CurrentFilter = filter.SearchFilter;

            // Actual work
            var selectedItems = this.Data.Categories.All();

            if (!string.IsNullOrEmpty(filter.SearchFilter))
            {
                selectedItems = selectedItems
                    .Where(x => x.Name.ToLower().Contains(filter.SearchFilter.ToLower()));
            }

            var sortedItems = selectedItems
                .Select(ListCategoryViewModel.ViewModel)
                .OrderBy(filter.Sorting);

            int pageSize = filter.PerPage;
            int pageNumber = filter.Page;

            return this.View(sortedItems.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                this.Data.Categories.Add(category);
                this.Data.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(category);
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
                return this.HttpNotFound();
            }

            return this.View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                this.Data.Categories.Update(category);
                this.Data.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(category);
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
                return this.HttpNotFound();
            }

            return this.View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = this.Data.Categories.Find(id);

            this.Data.Categories.Delete(category);
            this.Data.SaveChanges();

            return this.RedirectToAction("Index");
        }
    }
}
