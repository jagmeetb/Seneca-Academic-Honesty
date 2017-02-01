using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BTS.Startup))]
namespace BTS
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}
