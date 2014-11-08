using AffiliateNetwork.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AffiliateNetwork.Web.Areas.Administration.Controllers.Base
{
    public class AdminBaseController : Controller
    {
        private const int defaultPageSize = 1;

        public AdminBaseController(IDataProvider provider)
        {
            this.Data = provider;
        }

        public IDataProvider Data { get; set; }

        protected void ManagePageSizing()
        {
            int pagesize;

            if (!int.TryParse(Request.QueryString["perPage"], out pagesize))
            {
                pagesize = defaultPageSize;
            }

            ViewBag.PageSize = pagesize;
        }
    }

}