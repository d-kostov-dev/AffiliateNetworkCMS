using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AffiliateNetwork.Web.Startup))]

namespace AffiliateNetwork.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
