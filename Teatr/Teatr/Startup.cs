using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Teatr.Startup))]
namespace Teatr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
