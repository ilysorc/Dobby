using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DobbyMvcSample.Startup))]
namespace DobbyMvcSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
