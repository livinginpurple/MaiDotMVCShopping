using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaiDotMvcShopping.Startup))]
namespace MaiDotMvcShopping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
