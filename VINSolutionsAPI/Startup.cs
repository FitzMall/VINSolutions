using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VINSolutionsAPI.Startup))]
namespace VINSolutionsAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
