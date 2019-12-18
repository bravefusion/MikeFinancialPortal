using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MikeFinancialPortal.Startup))]
namespace MikeFinancialPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
