using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FetchNStore1.Startup))]
namespace FetchNStore1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
