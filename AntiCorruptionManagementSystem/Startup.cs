using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AntiCorruptionManagementSystem.Startup))]
namespace AntiCorruptionManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
