[assembly: Microsoft.Owin.OwinStartupAttribute(typeof(AffiliateNetwork.Web.Startup))]

namespace AffiliateNetwork.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
