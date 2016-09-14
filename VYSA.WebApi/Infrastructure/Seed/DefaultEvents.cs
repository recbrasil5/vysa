using System;
using System.Collections.Generic;
using VYSA.Domain.Entities;

namespace VYSA.WebApi.Infrastructure.Seed
{
    public class DefaultEvents
    {
        private const string lastUpdateBy = "VYSA.WebApi.Infrastructure";

        public static List<Event> Fall2015Events = new List<Event> 
        {
            #region events
            new Event
            {    
                Name = "CRSA Fall Pre-Season Tournament",
                City = "Marian",
                State = "IA",
                TournamentUrl = "http://www.crsoccer.com/continents-782749361-1/ChillOutTournament.html",
                StartDate = DateTime.Parse("8/18/2015"),
                EndDate = DateTime.Parse("8/19/2015"),
                Season = DefaultSeasons.Fall2015,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new Event
            {    
                Name = "Rush WI Fall Classic",
                City = "Middleton",
                State = "WI",
                TournamentUrl = "http://rushwisconsin.com/index.php/tournaments",
                StartDate = DateTime.Parse("9/24/2015"),
                EndDate = DateTime.Parse("9/26/2015"),
                Season = DefaultSeasons.Fall2015,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new Event
        {    
            Name = "Annual MC United Fall Cup",
            City = "Weston",
            State = "WI",
            TournamentUrl = "http://www.mcunitedsoccer.org/page/show/1371753-mcu-tournaments",
            StartDate = DateTime.Parse("10/2/2015"),
            EndDate = DateTime.Parse("10/3/2015"),
            Season = DefaultSeasons.Fall2015,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        },
        new Event
        {    
            Name = "Puma 2015 Annual Midwest Fall",
            City = "Milwaukee",
            State = "WI",
            TournamentUrl = "http://acesoccerclub.org/Page.asp?n=84026",
            StartDate = DateTime.Parse("11/8/2015"),
            EndDate = DateTime.Parse("11/10/2015"),
            Season = DefaultSeasons.Fall2015,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        },

        
        
        #endregion
        };

        public static List<Event> Spring2016Events = new List<Event> 
        {
            #region events
            new Event
            {    
                Name = "CRSA ChillOut Pre-Season Tournament",
                City = "Marian",
                State = "IA",
                TournamentUrl = "http://www.crsoccer.com/continents-782749361-1/ChillOutTournament.html",
                StartDate = DateTime.Parse("4/18/2016"),
                EndDate = DateTime.Parse("4/19/2016"),
                Season = DefaultSeasons.Summer2016,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new Event
            {    
                Name = "Rush WI Spring Classic",
                City = "Middleton",
                State = "WI",
                TournamentUrl = "http://rushwisconsin.com/index.php/tournaments",
                StartDate = DateTime.Parse("4/24/2016"),
                EndDate = DateTime.Parse("4/26/2016"),
                Season = DefaultSeasons.Fall2015,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new Event
        {    
            Name = "Annual Mountain Bay Cup",
            City = "Weston",
            State = "WI",
            TournamentUrl = "http://www.mcunitedsoccer.org/page/show/1371753-mcu-tournaments",
            StartDate = DateTime.Parse("5/2/2016"),
            EndDate = DateTime.Parse("5/3/2016"),
            Season = DefaultSeasons.Fall2015,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        },
        new Event
        {    
            Name = "Puma 2015 Annual Midwest Spring Soccerfest",
            City = "Milwaukee",
            State = "WI",
            TournamentUrl = "http://acesoccerclub.org/Page.asp?n=84026",
            StartDate = DateTime.Parse("5/8/2016"),
            EndDate = DateTime.Parse("5/10/2016"),
            Season = DefaultSeasons.Fall2015,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        },

        new Event
        {    
            Name = "2015 River Cup",
            City = "River Falls",
            State = "WI",
            TournamentUrl = "http://www.hudsonsoccer.com/34-2/",
            StartDate = DateTime.Parse("5/15/2016"),
            EndDate = DateTime.Parse("5/17/2016"),
            Season = DefaultSeasons.Fall2015,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        }
        #endregion
        };
    }
}