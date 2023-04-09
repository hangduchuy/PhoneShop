using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WEBPHONE.Startup))]
namespace WEBPHONE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
