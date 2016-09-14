using System;
using System.Collections.Generic;
using System.Data.Entity;
using VYSA.Domain.Concrete;
using VYSA.Domain.Entities;
using VYSA.Domain.Util;
using VYSA.WebApi.Infrastructure.Seed;

namespace VYSA.WebApi.Infrastructure
{
    public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<EfDbContext>
    {
        protected override void Seed(EfDbContext context)
        {
            InitializerUtil.SeedDatabase(context, false);
        }
    }
}