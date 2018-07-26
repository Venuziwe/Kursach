using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Institut.Startup))]
namespace Institut
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
