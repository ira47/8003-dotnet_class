using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NotesLibrary.Startup))]
namespace NotesLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
