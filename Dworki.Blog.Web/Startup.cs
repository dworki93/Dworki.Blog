using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dworki.Blog.Web.Startup))]
namespace Dworki.Blog.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
