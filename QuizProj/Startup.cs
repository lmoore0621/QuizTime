using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuizProj.Startup))]
namespace QuizProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
