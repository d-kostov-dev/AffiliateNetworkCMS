namespace AffiliateNetwork.Web.Controllers
{
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;

    using Microsoft.AspNet.Identity;

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