using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DatabseFirstDemo.Startup))]
namespace DatabseFirstDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
