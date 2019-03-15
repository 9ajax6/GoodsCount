using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoodsCount.Startup))]
namespace GoodsCount
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
