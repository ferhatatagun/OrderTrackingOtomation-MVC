using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_SiparisTakipSistemi.Startup))]
namespace _SiparisTakipSistemi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
