using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Z_StateOnline.UI.Startup))]
namespace Z_StateOnline.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
