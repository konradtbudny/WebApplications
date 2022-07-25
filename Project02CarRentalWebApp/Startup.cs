using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project02CarRentalWebApp.Startup))]
namespace Project02CarRentalWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
