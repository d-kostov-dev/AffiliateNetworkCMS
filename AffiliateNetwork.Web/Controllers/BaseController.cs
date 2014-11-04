namespace AffiliateNetwork.Web.Controllers
{
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;

    using Ninject;
    
    public class BaseController : Controller
    {
        public BaseController(IDataProvider provider)
        {
            this.Data = provider;
        }

        public IDataProvider Data { get; set; }
    }
}