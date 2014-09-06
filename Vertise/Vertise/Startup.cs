using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vertise.Startup))]
namespace Vertise
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureIoC(app);
            ConfigureAuth(app);
            
        }
    }
}
