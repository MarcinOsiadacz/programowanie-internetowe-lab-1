using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProgramowanieInternetowe.Startup))]
namespace ProgramowanieInternetowe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
