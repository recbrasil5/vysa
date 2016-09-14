using System;
using System.Collections.Generic;
using VYSA.Domain.Entities;

namespace VYSA.WebApi.Infrastructure.Seed
{
    public static class DefaultRosters
    {
        private const string lastUpdateBy = "VYSA.WebApi.Infrastructure";

        public static List<Roster> Fall2015U14Roster = new List<Roster>
        {
            new Roster
            {
                Team = DefaultTeams.TeamU14Boys,
                Player = DefaultPlayers.PlayerQuintinOlson,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new Roster
            {
                Team = DefaultTeams.TeamU14Boys,
                Player = DefaultPlayers.PlayerBraydon,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new Roster
            {
                Team = DefaultTeams.TeamU14Boys,
                Player = DefaultPlayers.PlayerSeanReick,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new Roster
            {
                Team = DefaultTeams.TeamU14Boys,
                Player = DefaultPlayers.PlayerCadenReed,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new Roster
            {
                Team = DefaultTeams.TeamU14Boys,
                Player = DefaultPlayers.PlayerCalebDeluww,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new Roster
            {
                Team = DefaultTeams.TeamU14Boys,
                Player = DefaultPlayers.PlayerKadenMoore,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new Roster
            {
                Team = DefaultTeams.TeamU14Boys,
                Player = DefaultPlayers.PlayerDaniel,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new Roster
            {
                Team = DefaultTeams.TeamU14Boys,
                Player = DefaultPlayers.PlayerDeejGarret,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new Roster
            {
                Team = DefaultTeams.TeamU14Boys,
                Player = DefaultPlayers.PlayerSpencerMalone,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new Roster
            {
                Team = DefaultTeams.TeamU14Boys,
                Player = DefaultPlayers.PlayerTyler,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new Roster
            {
                Team = DefaultTeams.TeamU14Boys,
                Player = DefaultPlayers.PlayerZachMueller,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new Roster
            {
                Team = DefaultTeams.TeamU14Boys,
                Player = DefaultPlayers.PlayerZakTurner,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            }
        };
    }
}