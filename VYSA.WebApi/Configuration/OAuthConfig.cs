using System;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;
using VYSA.WebApi.Providers;

namespace VYSA.WebApi.Configuration
{
    public static class OAuthConfig
    {
        public static void Configure(IAppBuilder app)
        {
            // Token Generation
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
//#if (DEBUG)
//                AllowInsecureHttp = true,
//#endif
                AllowInsecureHttp = true, 
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(3),
                Provider = new ApplicationOAuthProvider() // Provider is any class which inherits from OAuthAuthorizationServerProvider.
                //RefreshTokenProvider = new OAuthRefreshTokenProvider(DateTime.UtcNow.AddHours(8))
            });

            // Token Consumption
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                AuthenticationType = "Bearer",
                AuthenticationMode = AuthenticationMode.Active
            });
        }
    }
}