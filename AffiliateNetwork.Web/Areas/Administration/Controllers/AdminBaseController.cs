using AffiliateNetwork.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    public class AdminBaseController : Controller
    {

        public AdminBaseController(IDataProvider provider)
        {
            this.Data = provider;
        }

        public IDataProvider Data { get; set; }
    }

}