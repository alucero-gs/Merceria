using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MerceriaGit.Startup))]
namespace MerceriaGit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
