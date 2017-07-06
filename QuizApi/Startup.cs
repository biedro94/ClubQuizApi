using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuizApi.Startup))]
namespace QuizApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
