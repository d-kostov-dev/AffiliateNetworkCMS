namespace AffiliateNetwork.Web.Areas.Administration.Models.ViewModels
{
    using AffiliateNetwork.Infrastructure.Mapping;
    using AffiliateNetwork.Models;

    using AutoMapper;

    public class BannersListViewModel : IMapFrom<Banner>, IHaveCustomMappings
    {
        public string CampaignLandingPage { get; set; }

        public string BannerImage { get; set; }

        public string BannerCode { get; set; }

        public string CampaignTitle { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Banner, BannersListViewModel>()
                .ForMember(m => m.CampaignLandingPage, opt => opt.MapFrom(u => u.Campaign.LandingPage))
                .ForMember(m => m.BannerImage, opt => opt.MapFrom(u => u.Image))
                .ForMember(m => m.CampaignTitle, opt => opt.MapFrom(u => u.Campaign.Title))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}