using Microsoft.Owin.Cors;
using Owin;

namespace VYSA.WebApi.Configuration
{
    public static class CorsConfig
    {
        public static void Configure(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);  // not honoring domain restriction
        }
    }
}