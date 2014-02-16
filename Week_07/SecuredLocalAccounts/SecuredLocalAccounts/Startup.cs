using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecuredLocalAccounts.Startup))]
namespace SecuredLocalAccounts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
