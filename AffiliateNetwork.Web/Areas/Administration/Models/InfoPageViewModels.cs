using AffiliateNetwork.Common.Enumerations;
using AffiliateNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AffiliateNetwork.Web.Areas.Administration.Models
{
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
                    IsVisible = x.IsVisible
                };
            }
        }

        public int Id { get; set; }

        public string SeoUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int Order { get; set; }

        public YesNo IsVisible { get; set; }
    }
}