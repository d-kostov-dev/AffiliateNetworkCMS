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

namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    public class ConversionsController : Controller
    {
        private AffiliateNetworkDbContext db = new AffiliateNetworkDbContext();

        // GET: Administration/Conversions
        public ActionResult Index()
        {
            var conversions = db.Conversions.Include(c => c.Affiliate).Include(c => c.Campaign);
            return View(conversions.ToList());
        }

        // GET: Administration/Conversions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conversion conversion = db.Conversions.Find(id);
            if (conversion == null)
            {
                return HttpNotFound();
            }
            return View(conversion);
        }

        // GET: Administration/Conversions/Create
        public ActionResult Create()
        {
            ViewBag.AffiliateId = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.CampaignId = new SelectList(db.Campaigns, "Id", "Title");
            return View();
        }

        // POST: Administration/Conversions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AffiliateId,CampaignId,CreatedOn,ModifiedOn,DeletedOn")] Conversion conversion)
        {
            if (ModelState.IsValid)
            {
                db.Conversions.Add(conversion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AffiliateId = new SelectList(db.Users, "Id", "FirstName", conversion.AffiliateId);
            ViewBag.CampaignId = new SelectList(db.Campaigns, "Id", "Title", conversion.CampaignId);
            return View(conversion);
        }

        // GET: Administration/Conversions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conversion conversion = db.Conversions.Find(id);
            if (conversion == null)
            {
                return HttpNotFound();
            }
            ViewBag.AffiliateId = new SelectList(db.Users, "Id", "FirstName", conversion.AffiliateId);
            ViewBag.CampaignId = new SelectList(db.Campaigns, "Id", "Title", conversion.CampaignId);
            return View(conversion);
        }

        // POST: Administration/Conversions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AffiliateId,CampaignId,CreatedOn,ModifiedOn,DeletedOn")] Conversion conversion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conversion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AffiliateId = new SelectList(db.Users, "Id", "FirstName", conversion.AffiliateId);
            ViewBag.CampaignId = new SelectList(db.Campaigns, "Id", "Title", conversion.CampaignId);
            return View(conversion);
        }

        // GET: Administration/Conversions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conversion conversion = db.Conversions.Find(id);
            if (conversion == null)
            {
                return HttpNotFound();
            }
            return View(conversion);
        }

        // POST: Administration/Conversions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Conversion conversion = db.Conversions.Find(id);
            db.Conversions.Remove(conversion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
