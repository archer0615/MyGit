using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Crawler.Web.Startup))]
namespace Crawler.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
