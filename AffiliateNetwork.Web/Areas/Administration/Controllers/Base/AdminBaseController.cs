using AffiliateNetwork.Contracts;
using AffiliateNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;

namespace AffiliateNetwork.Web.Areas.Administration.Controllers.Base
{
    [Authorize]
    public class AdminBaseController : Controller
    {
        private const int defaultPageSize = 5;
        private IDictionary<string, string> settings;
        private User currentUser;

        public AdminBaseController(IDataProvider provider)
        {
            this.Data = provider;
            this.settings = this.GetSettings();
        }

        public IDataProvider Data { get; set; }

        public User CurrentUser
        {
            get
            {
                if(this.currentUser == null)
                {
                    var currentUserId = User.Identity.GetUserId();
                    this.currentUser = this.Data.Users.Find(currentUserId);
                }

                return this.currentUser;
            }
        }

        public string GetSetting(string key)
        {
            string result = null;

            if (this.settings.ContainsKey(key))
            {
                result = this.settings[key];
            }

            return result;
        }

        protected void ManagePageSizing()
        {
            int pagesize;

            if (!int.TryParse(Request.QueryString["perPage"], out pagesize))
            {
                pagesize = int.Parse(this.GetSetting("ItemsPerPage"));
            }

            ViewBag.PageSize = pagesize;
        }

        private IDictionary<string, string> GetSettings()
        {
            var settingsList = this.Data.SiteSettings.All().ToDictionary(x => x.Name, x => x.Value);
            this.ViewBag.Settings = settingsList;
            return settingsList;
        }
    }

}