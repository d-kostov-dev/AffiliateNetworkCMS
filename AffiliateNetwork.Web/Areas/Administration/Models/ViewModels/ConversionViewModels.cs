namespace AffiliateNetwork.Web.Areas.Administration.Models.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AffiliateNetwork.Infrastructure.Mapping;
    using AffiliateNetwork.Models;

    using AutoMapper;
    
    public class ConversionViewModels : IMapFrom<Conversion>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Affiliate Name")]
        public string AffiliateName { get; set; }

        [Display(Name = "Campaign Name")]
        public string CampaignName { get; set; }

        [Display(Name = "Conversion Date")]
        public DateTime CreatedOn { get; set; }

        public int CampaignId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Conversion, ConversionViewModels>()
                .ForMember(m => m.AffiliateName, opt => opt.MapFrom(u => u.Affiliate.UserName.ToString()))
                .ForMember(m => m.CampaignName, opt => opt.MapFrom(u => u.Campaign.Title.ToString()));
        }
    }
}