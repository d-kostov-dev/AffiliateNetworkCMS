using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AffiliateNetwork.Data;
using AffiliateNetwork.Models;
using AffiliateNetwork.Contracts;

namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    public class SiteSettingsController : AdminBaseController
    {
        private const int defaultPageSize = 1;

        public SiteSettingsController(IDataProvider provider)
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

            return View(this.Data.SiteSettings.All().OrderBy(x => x.Id).ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SiteSetting siteSetting)
        {
            if (ModelState.IsValid)
            {
                this.Data.SiteSettings.Add(siteSetting);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteSetting);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SiteSetting siteSetting = this.Data.SiteSettings.Find(id);

            if (siteSetting == null)
            {
                return HttpNotFound();
            }

            return View(siteSetting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SiteSetting siteSetting)
        {
            if (ModelState.IsValid)
            {
                this.Data.SiteSettings.Update(siteSetting);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteSetting);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SiteSetting siteSetting = this.Data.SiteSettings.Find(id);

            if (siteSetting == null)
            {
                return HttpNotFound();
            }

            return View(siteSetting);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteSetting siteSetting = this.Data.SiteSettings.Find(id);
            this.Data.SiteSettings.Delete(siteSetting);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
