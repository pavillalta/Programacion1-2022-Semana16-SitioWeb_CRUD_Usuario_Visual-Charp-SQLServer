using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Semana16_SitioWeb_CRUD_Usuario.Startup))]
namespace Semana16_SitioWeb_CRUD_Usuario
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
