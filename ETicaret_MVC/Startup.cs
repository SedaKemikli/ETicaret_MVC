using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ETicaret_MVC.Startup))]
namespace ETicaret_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
