namespace AffiliateNetwork.Web.Controllers
{
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;
    using Ninject;
    
    public class BaseController : Controller
    {
        protected IDataProvider data;

        public BaseController(IDataProvider provider)
        {
            this.data = provider;
        }
    }
}