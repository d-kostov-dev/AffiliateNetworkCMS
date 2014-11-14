namespace AffiliateNetwork.Web.Models
{
    using AffiliateNetwork.Infrastructure.Mapping;
    using AffiliateNetwork.Models;

    public class PagesFooterViewModel : IMapFrom<InfoPage>
    {
        public string SeoUrl { get; set; }

        public string Title { get; set; }
    }
}