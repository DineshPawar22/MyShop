using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyShop.webUI.Startup))]
namespace MyShop.webUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
