using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookLeague.WebMVC.Startup))]
namespace BookLeague.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
