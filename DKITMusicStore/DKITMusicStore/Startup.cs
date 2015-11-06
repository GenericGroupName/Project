using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DKITMusicStore.Startup))]
namespace DKITMusicStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
