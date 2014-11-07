using AffiliateNetwork.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AffiliateNetwork.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IDataProvider provider)
        {
            this.Data = provider;
        }

        public IDataProvider Data { get; set; }
    }
}