using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResQ.Startup))]
namespace ResQ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
