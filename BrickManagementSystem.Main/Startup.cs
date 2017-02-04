using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BrickManagementSystem.Main.Startup))]
namespace BrickManagementSystem.Main
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
