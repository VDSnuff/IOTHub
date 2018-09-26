using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IOTHub.Startup))]
namespace IOTHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
