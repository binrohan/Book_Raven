using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Book_Raven.Startup))]
namespace Book_Raven
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
