using Microsoft.Owin;
using Owin;
using AutoMapper;

[assembly: OwinStartupAttribute(typeof(Vidly18.Startup))]
namespace Vidly18
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
