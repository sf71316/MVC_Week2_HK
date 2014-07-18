using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Week1_HK.Startup))]
namespace MVC_Week1_HK
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          //  ConfigureAuth(app);
        }
    }
}
