using System;
using System.Collections.Generic;
using VYSA.Domain.Entities;
using VYSA.Domain.Enums;

namespace VYSA.WebApi.Infrastructure.Seed
{
    public static class DefaultSeasons
    {
        private const string lastUpdateBy = "VYSA.WebApi.Infrastructure";

        public static Season Fall2015 = new Season
        {
            Year = 2015,
            SeasonType = Enums.SeasonType.Fall,
            RegistrationDate = DateTime.Parse("06/11/2015"),
            StartDate = DateTime.Parse("08/17/2015"),
            EndDate = DateTime.Parse("10/30/2015"),
            Events = DefaultEvents.Fall2015Events,
            Teams = new List<Team>
            {
                DefaultTeams.TeamU10Boys, DefaultTeams.TeamU11Coed, DefaultTeams.TeamU11Girls,
                DefaultTeams.TeamU12Boys, DefaultTeams.TeamU13Boys, DefaultTeams.TeamU14Boys
            },
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Season Spring2016 = new Season
        {
            Year = 2015,
            SeasonType = Enums.SeasonType.Spring,
            RegistrationDate = DateTime.Parse("02/11/2016"),
            StartDate = DateTime.Parse("04/15/2016"),
            EndDate = DateTime.Parse("05/01/2016"),
            Events = DefaultEvents.Spring2016Events,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Season Summer2016 = new Season
        {
            Year = 2015,
            SeasonType = Enums.SeasonType.Summer,
            RegistrationDate = DateTime.Parse("04/11/2016"),
            StartDate = DateTime.Parse("06/01/2016"),
            EndDate = DateTime.Parse("07/01/2016"),
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };
    }
}