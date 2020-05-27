using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReservaDeVuelos.Startup))]
namespace ReservaDeVuelos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
