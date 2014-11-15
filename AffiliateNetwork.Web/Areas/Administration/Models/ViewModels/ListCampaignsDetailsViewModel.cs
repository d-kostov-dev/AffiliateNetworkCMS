namespace AffiliateNetwork.Web.Areas.Administration.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AffiliateNetwork.Common.Enumerations;
    using AffiliateNetwork.Infrastructure.Mapping;
    using AffiliateNetwork.Models;

    using AutoMapper;

    public class ListCampaignsDetailsViewModel : IMapFrom<Campaign>, IHaveCustomMappings
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

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Expires")]
        public DateTime ValidTo { get; set; }

        [Display(Name = "Clicks")]
        public ICollection<Click> Clicks { get; set; }

        [Display(Name = "Conversions")]
        public ICollection<Conversion> Conversions { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }

        [Display(Name = "Created")]
        public DateTime CreatedOn { get; set; }

        public string OwnerId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Campaign, ListCampaignsDetailsViewModel>()
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(u => u.Category.Name.ToString()))
                .ForMember(m => m.CompanyName, opt => opt.MapFrom(u => u.Owner.CompanyName));
        }
    }
}