﻿namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;
    using AffiliateNetwork.Web.Areas.Administration.Controllers.Base;

    public class BannersController : AdminBaseController
    {
        public BannersController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult Index()
        {
            this.ManagePageSizing();
            var banners = this.Data.Banners.All().OrderByDescending(x => x.Id);

            return this.View(banners);
        }

        public ActionResult Add(int? id)
        {
            if (id == null)
            {
                return this.RedirectToAction("Index", "Campaigns");
            }
            var campaign = this.Data.Campaigns.Find(id);

            if (campaign.OwnerId != this.CurrentUser.Id)
            {
                return this.RedirectToAction("Index", "Campaigns");
            }

            var banner = new Banner() { CampaignId = (int)id };

            return this.View(banner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Banner banner, HttpPostedFileBase banerUploaded)
        {
            if (banerUploaded != null && banerUploaded.ContentLength > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".png", ".gif", ".jpeg" };
                var extension = Path.GetExtension(banerUploaded.FileName);

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError(string.Empty, "File type not supported");
                }
                else
                {
                    var fileName = banner.CampaignId.ToString() + Guid.NewGuid().ToString() + extension;
                    var path = Path.Combine(Server.MapPath("~/Content/Banners/"), fileName);

                    banerUploaded.SaveAs(path);
                    banner.Image = fileName;
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please upload file!");
            }

            if (!ModelState.IsValid)
            {
                return this.View();
            }

            this.Data.Banners.Add(banner);
            this.Data.SaveChanges();

            return this.RedirectToAction("Details", "Campaigns", new { id = banner.CampaignId });
        }

        public ActionResult DeleteConfirmed(int id)
        {
            Banner banner = this.Data.Banners.Find(id);

            string fullPath = Request.MapPath("~/Content/Banners/" + banner.Image);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            this.Data.Banners.TotalDelete(banner);
            this.Data.SaveChanges();

            return this.RedirectToAction("Index");
        }
    }
}
