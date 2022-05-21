using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResturantSystem.Startup))]
namespace ResturantSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
