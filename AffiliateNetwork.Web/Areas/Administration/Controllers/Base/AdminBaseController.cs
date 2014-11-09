using AffiliateNetwork.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AffiliateNetwork.Web.Areas.Administration.Controllers.Base
{
    [Authorize]
    public class AdminBaseController : Controller
    {
        private const int defaultPageSize = 5;
        private IDictionary<string, string> settings;

        public AdminBaseController(IDataProvider provider)
        {
            this.Data = provider;
            this.settings = this.GetSettings();
        }

        public IDataProvider Data { get; set; }

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

        //protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        //{
        //    this.ViewBag.Settings = this.GetSettings();
        //    this.settings = this.GetSettings();
        //    return base.BeginExecute(requestContext, callback, state);
        //}

        private IDictionary<string, string> GetSettings()
        {
            var settingsList = this.Data.SiteSettings.All().ToDictionary(x => x.Name, x => x.Value);
            this.ViewBag.Settings = settingsList;
            return settingsList;
        }
    }

}