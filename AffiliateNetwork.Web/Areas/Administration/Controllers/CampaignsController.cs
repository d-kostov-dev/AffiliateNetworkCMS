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
    public class CampaignsController : AdminBaseController
    {
        public CampaignsController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult Index()
        {
            return View(this.Data.Campaigns.All().OrderBy(x => x.Id).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Campaign campaign = this.Data.Campaigns.Find(id);

            if (campaign == null)
            {
                return HttpNotFound();
            }

            return View(campaign);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                this.Data.Campaigns.Add(campaign);
                this.Data.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(campaign);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Campaign campaign = this.Data.Campaigns.Find(id);

            if (campaign == null)
            {
                return HttpNotFound();
            }

            return View(campaign);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                this.Data.Campaigns.Update(campaign);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campaign);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Campaign campaign = this.Data.Campaigns.Find(id);

            if (campaign == null)
            {
                return HttpNotFound();
            }

            return View(campaign);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campaign campaign = this.Data.Campaigns.Find(id);
            this.Data.Campaigns.Delete(campaign);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
