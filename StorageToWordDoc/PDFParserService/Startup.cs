using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PDFParserService.Startup))]
namespace PDFParserService
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
