using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Portal.Startup))]
namespace Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
