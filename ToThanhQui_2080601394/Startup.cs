using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToThanhQui_2080601394.Startup))]
namespace ToThanhQui_2080601394
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
