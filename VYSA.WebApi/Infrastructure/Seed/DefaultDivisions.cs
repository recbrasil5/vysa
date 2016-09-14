﻿using System;
using VYSA.Domain.Entities;
using VYSA.Domain.Enums;

namespace VYSA.WebApi.Infrastructure.Seed
{
    public static class DefaultDivisions
    {
        private const string lastUpdateBy = "VYSA.WebApi.Infrastructure";

        public static Division U10Boys = new Division
        {
            AgeLimit = 10,
            GenderCode = Enums.GenderCode.Boys,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Division U11Coed = new Division
        {
            AgeLimit = 11,
            GenderCode = Enums.GenderCode.Coed,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Division U11Girls = new Division
        {
            AgeLimit = 11,
            GenderCode = Enums.GenderCode.Girls,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Division U12Boys = new Division
        {
            AgeLimit = 12,
            GenderCode = Enums.GenderCode.Boys,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Division U13Boys = new Division
        {
            AgeLimit = 13,
            GenderCode = Enums.GenderCode.Boys,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Division U14Boys = new Division
        {
            AgeLimit = 14,
            GenderCode = Enums.GenderCode.Boys,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Division U13Girls = new Division
        {
            AgeLimit = 14,
            GenderCode = Enums.GenderCode.Girls,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Division U17Boys = new Division
        {
            AgeLimit = 17,
            GenderCode = Enums.GenderCode.Boys,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };
    }
}