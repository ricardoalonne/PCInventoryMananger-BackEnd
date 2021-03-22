using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

using PCIM.dat;

[assembly: OwinStartup(typeof(PCIM.api.Startup))]

namespace PCIM.api
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Para obtener más información sobre cómo configurar la aplicación, visite https://go.microsoft.com/fwlink/?LinkID=316888
            app.CreatePerOwinContext(PCIMContext.Create);
        }
    }
}
