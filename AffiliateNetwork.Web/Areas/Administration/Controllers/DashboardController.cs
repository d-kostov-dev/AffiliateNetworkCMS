namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Web.Areas.Administration.Controllers.Base;
    using AffiliateNetwork.Web.Areas.Administration.Models.ViewModels;
    
    public class DashboardController : AdminBaseController
    {
        public DashboardController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult Index()
        {
            var statisticsData = new DashboardViewModel();

            statisticsData.TotalCampaigns = this.Data.Campaigns.All().Count();
            statisticsData.TotalClicks = this.Data.Clicks.All().Count();
            statisticsData.TotalConversions = this.Data.Conversions.All().Count();
            statisticsData.TotalBanners = this.Data.Banners.All().Count();
            statisticsData.TotalUsers = this.Data.Users.All().Count();

            return this.View(statisticsData);
        }
    }
}