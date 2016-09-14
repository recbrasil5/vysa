﻿using System;
using VYSA.Domain.Entities;

namespace VYSA.WebApi.Infrastructure.Seed
{
    public static class DefaultCoaches
    {
        private const string lastUpdateBy = "VYSA.WebApi.Infrastructure";

        public static Coach CoachNick = new Coach
        {
            FirstName = "Nick",
            LastName = "Turner",
            Email = "recbrasil5@gmail.com",
            Phone = "(608) 385-3649",
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Coach CoachAndy = new Coach
        {
            FirstName = "Andy",
            LastName = "Olson",
            Email = "andy@gmail.com",
            Phone = "(608) 355-3649",
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Coach CoachMark = new Coach
        {
            FirstName = "Mark",
            LastName = "Carrk",
            Email = "andy@gmail.com",
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Coach CoachZach = new Coach
        {
            FirstName = "Zach",
            LastName = "Berg",
            Email = "andy@gmail.com",
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Coach CoachBruce = new Coach
        {
            FirstName = "Bruce",
            LastName = "Waldron",
            Email = "bwaldo1970@charter.net",
            Phone = "(608) 792-7268",
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Coach CoachLori = new Coach
        {
            FirstName = "Lori",
            LastName = "Bembnister",
            Email = "snieglm@hotmail.com",
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Coach CoachManuel = new Coach
        {
            FirstName = "Manuel",
            LastName = "Saurez",
            Email = "suarezmanuelj@gmail.com",
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };
    }
}