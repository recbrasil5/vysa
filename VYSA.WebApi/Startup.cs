﻿using System.Data.Entity;
using System.Diagnostics;
using Microsoft.Owin;
using Owin;
using VYSA.Domain.Concrete;
using VYSA.Domain.Cryptography;
using VYSA.WebApi;
using VYSA.WebApi.Configuration;
using VYSA.WebApi.Infrastructure;

[assembly: OwinStartup(typeof(Startup))]

namespace VYSA.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            CorsConfig.Configure(app);
            OAuthConfig.Configure(app);
            WebApiConfig.Configure(app);

#if DEBUG
            Database.SetInitializer(new DropCreateIfChangeInitializer()); //rebuilds database if model changes
            //Database.SetInitializer(new CreateInitializer()); //build pre-production - only creates database if it doesn't exist.
#else
            Database.SetInitializer<EFDbContext>(null); //production - do nothing
#endif

            using (var dbContext = new EfDbContext())
            {
                dbContext.Database.Initialize(true);
            }
        }
    }
}
