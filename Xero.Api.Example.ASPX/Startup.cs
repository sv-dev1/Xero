using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Xero.Api.Example.ASPX.Startup))]
namespace Xero.Api.Example.ASPX
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
