using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GitLab.Startup))]
namespace GitLab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
