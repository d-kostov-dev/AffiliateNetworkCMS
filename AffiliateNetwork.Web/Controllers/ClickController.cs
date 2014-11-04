namespace AffiliateNetwork.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;
    using AffiliateNetwork.Web.Filters;

    public class ClickController : Controller
    {
        private IDataProvider data;

        public ClickController(IDataProvider data)
        {
            this.data = data;
        }

        [AllowCors]
        public void RegisterClick(string affId)
        {
            this.data.Clicks.Add(new Click() { Affiliate = this.data.Users.Find(affId), DateMade = DateTime.Now});
            this.data.SaveChanges();
        }
    }
}