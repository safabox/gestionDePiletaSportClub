using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gestionDePiletaSportClub.Startup))]
namespace gestionDePiletaSportClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
