using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DentalSoft.Startup))]
namespace DentalSoft
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
