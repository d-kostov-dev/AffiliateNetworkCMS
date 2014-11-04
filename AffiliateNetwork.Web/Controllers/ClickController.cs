namespace AffiliateNetwork.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;
    using AffiliateNetwork.Web.Filters;

    public class ClickController : BaseController
    {
        public ClickController(IDataProvider provider)
            :base(provider)
        {
        }

        [AllowCors]
        public void RegisterClick(string affId)
        {
            this.Data.Clicks.Add(new Click() { Affiliate = this.Data.Users.Find(affId), DateMade = DateTime.Now });
            this.Data.SaveChanges();
        }
    }
}