using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ES1.Startup))]
namespace ES1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
