using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WiwAPISite.Startup))]
namespace WiwAPISite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
