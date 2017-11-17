using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(INTIERO.Startup))]
namespace INTIERO
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
