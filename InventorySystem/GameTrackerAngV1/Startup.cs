using GameTrackerAngV1;
using Microsoft.Owin;
using Owin;
using Startup = GameTrackerAngV1.Startup;

[assembly: OwinStartupAttribute(typeof(Startup))]
namespace GameTrackerAngV1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
