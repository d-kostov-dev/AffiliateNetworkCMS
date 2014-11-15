namespace AffiliateNetwork.Web.Areas.Administration.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;

    using AffiliateNetwork.Models;

    public class ListInfoPageViewModel
    {
        public static Expression<Func<InfoPage, ListInfoPageViewModel>> ViewModel
        {
            get
            {
                return x => new ListInfoPageViewModel()
                {
                    Id = x.Id,
                    SeoUrl = x.SeoUrl,
                    Title = x.Title,
                    Content = x.Content.Substring(0, 50),
                    Order = x.Order,
                    IsVisible = x.DeletedOn == null ? true : false,
                    CreatedOn = x.CreatedOn
                };
            }
        }

        public int Id { get; set; }

        public string SeoUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int Order { get; set; }

        public bool IsVisible { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}