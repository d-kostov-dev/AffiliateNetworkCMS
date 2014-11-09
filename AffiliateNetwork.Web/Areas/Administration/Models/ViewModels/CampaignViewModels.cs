namespace AffiliateNetwork.Web.Areas.Administration.Models.ViewModels
{
    using System;

    using AffiliateNetwork.Infrastructure.Mapping;
    using AffiliateNetwork.Models;
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;
    using AffiliateNetwork.Common.Enumerations;

    public class ListCampaignsViewModel : IMapFrom<Campaign>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Type")]
        public virtual CampaignType Type { get; set; }

        [Display(Name = "Landing Page")]
        public string LandingPage { get; set; }

        public decimal Payout { get; set; }

        [Display(Name = "Owner")]
        public virtual User Owner { get; set; }

        [Display(Name = "Affiliates")]
        public int AffiliatesCount { get; set; }

        [Display(Name = "Expires")]
        public DateTime ValidTo { get; set; }

        [Display(Name = "Clicks")]
        public int ClicksCount;

        [Display(Name = "Conversions")]
        public int ConversionsCount;

        public ApprovalStatus ApprovalStatus { get; set; }

        [Display(Name = "Created")]
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Campaign, ListCampaignsViewModel>()
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(u => u.Category.Name.ToString()));

            configuration.CreateMap<Campaign, ListCampaignsViewModel>()
                .ForMember(m => m.AffiliatesCount, opt => opt.MapFrom(u => u.Affiliates.Count));

            configuration.CreateMap<Campaign, ListCampaignsViewModel>()
                .ForMember(m => m.ClicksCount, opt => opt.MapFrom(u => u.Clicks.Count));

            configuration.CreateMap<Campaign, ListCampaignsViewModel>()
                .ForMember(m => m.ConversionsCount, opt => opt.MapFrom(u => u.Conversions.Count));
        }
    }

    public class ListCampaignsDetailsViewModel : IMapFrom<Campaign>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Type")]
        public virtual CampaignType Type { get; set; }

        [Display(Name = "Landing Page")]
        public string LandingPage { get; set; }

        public decimal Payout { get; set; }

        [Display(Name = "Owner")]
        public virtual User Owner { get; set; }

        [Display(Name = "Affiliates")]
        public int AffiliatesCount { get; set; }

        [Display(Name = "Expires")]
        public DateTime ValidTo { get; set; }

        [Display(Name = "Clicks")]
        public int ClicksCount;

        [Display(Name = "Conversions")]
        public int ConversionsCount;

        public ApprovalStatus ApprovalStatus { get; set; }

        [Display(Name = "Created")]
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Campaign, ListCampaignsViewModel>()
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(u => u.Category.Name.ToString()));

            configuration.CreateMap<Campaign, ListCampaignsViewModel>()
                .ForMember(m => m.AffiliatesCount, opt => opt.MapFrom(u => u.Affiliates.Count));

            configuration.CreateMap<Campaign, ListCampaignsViewModel>()
                .ForMember(m => m.ClicksCount, opt => opt.MapFrom(u => u.Clicks.Count));

            configuration.CreateMap<Campaign, ListCampaignsViewModel>()
                .ForMember(m => m.ConversionsCount, opt => opt.MapFrom(u => u.Conversions.Count));
        }
    }
}