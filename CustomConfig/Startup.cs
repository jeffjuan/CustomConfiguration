using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomConfig.Startup))]
namespace CustomConfig
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
