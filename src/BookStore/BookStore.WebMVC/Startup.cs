using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(BookStore.WebMVC.Startup))]
namespace BookStore.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
