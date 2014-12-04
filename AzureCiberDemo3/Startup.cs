using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzureCiberDemo3.Startup))]
namespace AzureCiberDemo3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
