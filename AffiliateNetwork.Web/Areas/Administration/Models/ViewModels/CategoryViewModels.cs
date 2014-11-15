namespace AffiliateNetwork.Web.Areas.Administration.Models.ViewModels
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using AffiliateNetwork.Models;

    public class ListCategoryViewModel
    {
        public static Expression<Func<Category, ListCategoryViewModel>> ViewModel
        {
            get
            {
                return x => new ListCategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CampaignsCount = x.Campaigns.Where(c => c.DeletedOn == null).Count(),
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CampaignsCount { get; set; }
    }
}