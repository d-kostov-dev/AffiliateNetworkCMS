using AffiliateNetwork.Contracts;
using AffiliateNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace AffiliateNetwork.Web.Controllers
{
    public class BaseController : Controller
    {
        private User currentUser;

        public BaseController(IDataProvider provider)
        {
            this.Data = provider;
        }

        public IDataProvider Data { get; set; }

        public User CurrentUser
        {
            get
            {
                if (this.currentUser == null)
                {
                    var currentUserId = User.Identity.GetUserId();
                    this.currentUser = this.Data.Users.Find(currentUserId);
                }

                return this.currentUser;
            }
        }
    }
}