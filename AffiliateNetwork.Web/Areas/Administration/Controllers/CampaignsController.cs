namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;
    using AffiliateNetwork.Web.Areas.Administration.Controllers.Base;
    using AffiliateNetwork.Web.Areas.Administration.Models.InputModels;
    using AffiliateNetwork.Web.Areas.Administration.Models.ViewModels;
    using AffiliateNewtork.Common;

    using AutoMapper.QueryableExtensions;
    using System.Text;

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

            return this.View(campaigns);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var campaign =
                this.Data.Campaigns.All()
                .Where(x => x.Id == id)
                .Project().To<ListCampaignsDetailsViewModel>()
                .FirstOrDefault();

            var clicksByMonth = campaign.Clicks
                .GroupBy(x => x.CreatedOn.Month)
                .Select(c => new { Month = c.Key, Count = c.Count() }).ToList();

            var conversionsByMonth = ViewBag.Conversions = campaign.Conversions
                .GroupBy(x => x.CreatedOn.Month)
                .Select(c => new { Month = c.Key, Count = c.Count() }).ToList();

            var clicksArray = new int[12];
            var conversionsArray = new int[12];

            for (int i = 0; i < clicksByMonth.Count; i++)
            {
                clicksArray[clicksByMonth[i].Month - 1] = clicksByMonth[i].Count;
            }

            for (int i = 0; i < conversionsByMonth.Count; i++)
            {
                conversionsArray[conversionsByMonth[i].Month - 1] = conversionsByMonth[i].Count;
            }

            ViewBag.Clicks = clicksArray;
            ViewBag.Conversions = conversionsArray;
            ViewBag.MaxClicks = (int)(clicksArray.Max() * 1.5);

            if (campaign == null)
            {
                return this.HttpNotFound();
            }

            return this.View(campaign);
        }

        public ActionResult Create()
        {
            this.SetCategories();

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CampaignCreateEditViewModel campaign)
        {
            if (!ModelState.IsValid)
            {
                this.SetCategories();
                return this.View(campaign);
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

            return this.RedirectToAction("Index");
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
                return this.HttpNotFound();
            }

            if (campaign.OwnerId != this.CurrentUser.Id && !User.IsInRole(GlobalConstants.AdminRole))
            {
                return this.RedirectToAction("Index");
            }

            this.SetCategories(campaign.CategoryId);

            return this.View(campaign);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CampaignCreateEditViewModel campaign)
        {
            if (!ModelState.IsValid)
            {
                return this.View(campaign);
            }

            var campaignToSave = this.Data.Campaigns.Find(campaign.Id);

            if (campaignToSave.OwnerId != this.CurrentUser.Id && !User.IsInRole(GlobalConstants.AdminRole))
            {
                return this.RedirectToAction("Index");
            }

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

            return this.RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var campaign =
                this.Data.Campaigns.All()
                .Where(x => x.Id == id)
                .Project().To<ListCampaignsDetailsViewModel>()
                .FirstOrDefault();

            var clicksByMonth = campaign.Clicks
                .GroupBy(x => x.CreatedOn.Month)
                .Select(c => new { Month = c.Key, Count = c.Count() }).ToList();

            var conversionsByMonth = campaign.Conversions
                .GroupBy(x => x.CreatedOn.Month)
                .Select(c => new { Month = c.Key, Count = c.Count() }).ToList();

            var clicksArray = new int[12];
            var conversionsArray = new int[12];

            for (int i = 0; i < clicksByMonth.Count; i++)
            {
                clicksArray[clicksByMonth[i].Month - 1] = clicksByMonth[i].Count;
            }

            for (int i = 0; i < conversionsByMonth.Count; i++)
            {
                conversionsArray[conversionsByMonth[i].Month - 1] = conversionsByMonth[i].Count;
            }

            ViewBag.Clicks = clicksArray;
            ViewBag.Conversions = conversionsArray;
            ViewBag.MaxClicks = clicksArray.Max() * 2;

            if (campaign == null)
            {
                return this.HttpNotFound();
            }

            return this.View(campaign);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campaign campaign = this.Data.Campaigns.Find(id);

            if (campaign.OwnerId != this.CurrentUser.Id && !User.IsInRole(GlobalConstants.AdminRole))
            {
                return this.RedirectToAction("Index");
            }

            this.Data.Campaigns.Delete(campaign);
            this.Data.SaveChanges();

            return this.RedirectToAction("Index");
        }

        public ActionResult AddBanner(int id)
        {
            return this.RedirectToAction("Add", "Banners", new { id = id });
        }

        public ActionResult TrackingCodeModal(int id)
        {
            var trackingCode = new StringBuilder();

            trackingCode.Append(
                string.Format("<script src='{0}'></script>", 
                this.GetSetting("TrakingScriptUrl")));

            trackingCode.Append(string.Format("<script>makeClick({0});</script>", id));

            return this.PartialView("_TrackingCodePartial", trackingCode.ToString());
        }

        private void SetCategories(int? id = null)
        {
            var items = new SelectList(this.Data.Categories.All().ToList(), "Id", "Name", id.ToString());

            ViewBag.CategoryCollection = items;
        }
    }
}
