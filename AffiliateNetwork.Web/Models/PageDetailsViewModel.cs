namespace AffiliateNetwork.Web.Models
{
    using AffiliateNetwork.Infrastructure.Mapping;
    using AffiliateNetwork.Models;

    public class PageDetailsViewModel : IMapFrom<InfoPage>
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}