namespace AffiliateNetwork.Web.Controllers
{
    using System;

    using AffiliateNetwork.Common.Enumerations;
    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Infrastructure.Filters;
    using AffiliateNetwork.Models;

    public class ClicksController : BaseController
    {
        public ClicksController(IDataProvider provider)
            : base(provider)
        {
        }

        [AllowCors]
        public void RegisterClick(string affId, int campaignId)
        {
            var currentClick = new Click()
            {
                AffiliateId = affId,
                CampaignId = campaignId
            };

            var currentCampaign = this.Data.Campaigns.Find(campaignId);

            if (currentCampaign.Type == CampaignType.CPC)
            {
                if (currentCampaign.ValidTo > DateTime.Now)
                {
                    var userToCredit = this.Data.Users.Find(affId);
                    userToCredit.Credits += currentCampaign.Payout;
                }
            }

            this.Data.Clicks.Add(currentClick);
            this.Data.SaveChanges();
        }
    }
}