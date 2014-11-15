namespace AffiliateNetwork.Web.Areas.Administration.Models.ViewModels
{
    using AffiliateNetwork.Infrastructure.Mapping;
    using AffiliateNetwork.Models;
    using AutoMapper;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ClicksListViewModels : IMapFrom<Click>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Affiliate Name")]
        public string AffiliateName { get; set; }

        [Display(Name = "Campaign Name")]
        public string CampaignName { get; set; }

        [Display(Name = "Click Date")]
        public DateTime CreatedOn { get; set; }

        public int CampaignId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Click, ClicksListViewModels>()
                .ForMember(m => m.AffiliateName, opt => opt.MapFrom(u => u.Affiliate.UserName.ToString()))
                .ForMember(m => m.CampaignName, opt => opt.MapFrom(u => u.Campaign.Title.ToString()));
        }
    }
}