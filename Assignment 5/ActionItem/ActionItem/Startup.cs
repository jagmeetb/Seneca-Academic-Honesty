using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ActionItem.Startup))]
namespace ActionItem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
