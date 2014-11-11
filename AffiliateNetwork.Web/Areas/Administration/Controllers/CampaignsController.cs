namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;
    using AffiliateNetwork.Web.Areas.Administration.Controllers.Base;
    using AffiliateNetwork.Web.Areas.Administration.Models.InputModels;
    using AffiliateNetwork.Web.Areas.Administration.Models.ViewModels;

    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;

    public class CampaignsController : AdminBaseController
    {
        public CampaignsController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult Index()
        {
            this.ManagePageSizing();

            var campaigns =
                this.Data.Campaigns
                .All()
                .OrderBy(x => x.Id)
                .Project().To<ListCampaignsViewModel>();

            return View(campaigns);
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
            this.SetCategories();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CampaignCreateEditViewModel campaign)
        {
            if (!ModelState.IsValid)
            {
                this.SetCategories();
                return View(campaign);
            }

            var campaignToAdd = new Campaign()
            {
                Title = campaign.Title,
                Description = campaign.Description,
                Payout = campaign.Payout,
                LandingPage = campaign.LandingPage,
                ValidTo = campaign.ValidTo,
                OwnerId = this.CurrentUser.Id,
                CategoryId = campaign.CategoryId,
                ApprovalStatus = campaign.ApprovalStatus,
                Type = campaign.Type,
            };

            this.Data.Campaigns.Add(campaignToAdd);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var campaign =
                this.Data.Campaigns
                .All()
                .Project().To<CampaignCreateEditViewModel>()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (campaign == null)
            {
                return HttpNotFound();
            }

            this.SetCategories(campaign.CategoryId);

            return View(campaign);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CampaignCreateEditViewModel campaign)
        {
            if (!ModelState.IsValid)
            {
                return View(campaign);
            }

            var campaignToSave = this.Data.Campaigns.Find(campaign.Id);

            campaignToSave.Title = campaign.Title;
            campaignToSave.Description = campaign.Description;
            campaignToSave.Payout = campaign.Payout;
            campaignToSave.LandingPage = campaign.LandingPage;
            campaignToSave.ValidTo = campaign.ValidTo;
            campaignToSave.CategoryId = campaign.CategoryId;
            campaignToSave.ApprovalStatus = campaign.ApprovalStatus;
            campaignToSave.Type = campaign.Type;

            this.Data.Campaigns.Update(campaignToSave);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
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

        public ActionResult AddBanner(int id)
        {
            return RedirectToAction("Add", "Banners", new { id = id });
        }

        private void SetCategories(int? id = null)
        {
            var items = new SelectList(this.Data.Categories.All().ToList(), "Id", "Name", id.ToString());

            ViewBag.CategoryCollection = items;
        }
    }
}
