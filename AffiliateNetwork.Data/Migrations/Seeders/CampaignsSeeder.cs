namespace AffiliateNetwork.Data.Migrations.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using AffiliateNetwork.Common.Enumerations;
    using AffiliateNetwork.Models;

    public class CampaignsSeeder
    {
        private const string DefaultDescriptionText = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";

        private const string DefaultLandingPage = "https://telerikacademy.com/";

        public static void Seed(AffiliateNetworkDbContext databaseContext)
        {
            var defaultCampaigns = new List<Campaign>()
            {
                new Campaign()
                {
                    Title = "Online Sports Shop",
                    Type = CampaignType.CPA,
                    CategoryId = 1,
                    Payout = 1.2m,
                    ApprovalStatus = ApprovalStatus.Approved
                },
                new Campaign()
                {
                    Title = "Book Store Bg",
                    Type = CampaignType.CPA,
                    CategoryId = 2,
                    Payout = 2.6m,
                    ApprovalStatus = ApprovalStatus.Waiting
                },
                new Campaign()
                {
                    Title = "Forex Trader Online",
                    Type = CampaignType.CPA,
                    CategoryId = 3,
                    Payout = 5.5m,
                    ApprovalStatus = ApprovalStatus.Disapproved
                },
                new Campaign()
                {
                    Title = "Weight Loss Pills",
                    Type = CampaignType.CPC,
                    CategoryId = 4,
                    Payout = 0.10m,
                    ApprovalStatus = ApprovalStatus.Approved
                },
                new Campaign()
                {
                    Title = "Praktiker Campaign",
                    Type = CampaignType.CPC,
                    CategoryId = 5,
                    Payout = 0.30m,
                    ApprovalStatus = ApprovalStatus.Waiting
                },
                new Campaign()
                {
                    Title = "Jumbo Toys",
                    Type = CampaignType.CPC,
                    CategoryId = 6,
                    Payout = 0.45m,
                    ApprovalStatus = ApprovalStatus.Approved
                }
            };

            for (int i = 0; i < defaultCampaigns.Count; i++)
            {
                var currentCampaign = defaultCampaigns[i];
                currentCampaign.Id = i + 1;
                currentCampaign.Description = DefaultDescriptionText;
                currentCampaign.LandingPage = DefaultLandingPage;
                currentCampaign.ValidTo = DateTime.Now.AddDays(30);
                currentCampaign.OwnerId = 
                    databaseContext.Users.Where(x => x.UserName == "admin@abv.bg").FirstOrDefault().Id;
                currentCampaign.CreatedOn = DateTime.Now;

                databaseContext.Campaigns.AddOrUpdate(currentCampaign);
            }

            databaseContext.SaveChanges();
        }
    }
}
