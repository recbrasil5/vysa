﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using VYSA.Domain.Concrete;
using VYSA.Domain.Entities;
using VYSA.WebApi.Infrastructure.Seed;

namespace VYSA.WebApi.Infrastructure
{
    public class CreateInitializer : CreateDatabaseIfNotExists<EfDbContext>
    {
        protected override void Seed(EfDbContext context)
        {
            InitializerUtil.SeedDatabase(context, true);
        }

    }
}