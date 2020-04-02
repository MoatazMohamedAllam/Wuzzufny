using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wuzzufny.Startup))]
namespace Wuzzufny
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
