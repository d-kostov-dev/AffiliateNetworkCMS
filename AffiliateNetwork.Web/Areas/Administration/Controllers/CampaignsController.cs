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
                OwnerId = User.Identity.GetUserId(),
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

            Campaign campaign = this.Data.Campaigns.Find(id);

            if (campaign == null)
            {
                return HttpNotFound();
            }

            this.SetCategories(campaign.Category.Id);

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

        private void SetCategories(int? id = null)
        {
            //IEnumerable<SelectListItem> items =
            //    this.Data.Categories
            //    .All()
            //    .Select(c => new SelectListItem 
            //    { 
            //        Value = c.Id.ToString(), 
            //        Text = c.Name, 
            //        Selected = c.Id == id ? true : false 
            //    });

            var items = new SelectList(this.Data.Categories.All().ToList(), "Id", "Name", id.ToString());

            ViewBag.CategoryCollection = items;
        }
    }
}
