using System;
using VYSA.Domain.Entities;

namespace VYSA.WebApi.Infrastructure.Seed
{
    public static class DefaultBoardMembers
    {
        private const string lastUpdateBy = "VYSA.WebApi.Infrastructure";

        public static BoardMember bmAlHanson = new BoardMember
        {
            User = DefaultUsers.userAl,
            KeyValue = DefaultKeyValues.President,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static BoardMember bmJoshKipp = new BoardMember
        {
            User = DefaultUsers.userBruce,
            KeyValue = DefaultKeyValues.VicePresident,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static BoardMember bmTaraRieck = new BoardMember
        {
            User = DefaultUsers.userTara,
            KeyValue = DefaultKeyValues.Treasurer,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static BoardMember bmStacyFoster = new BoardMember
        {
            User = DefaultUsers.userStacey,
            KeyValue = DefaultKeyValues.Secretary,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static BoardMember bmShannonSchneider = new BoardMember
        {
            User = DefaultUsers.userShannon,
            KeyValue = DefaultKeyValues.FundraisingDirector,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static BoardMember bmSteveOlson = new BoardMember
        {
            User = DefaultUsers.userSteve,
            KeyValue = DefaultKeyValues.TournamentDirector,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static BoardMember bmAndyOlson = new BoardMember
        {
            User = DefaultUsers.userAndy,
            KeyValue = DefaultKeyValues.CoachingDirector,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static BoardMember bmPatRotering = new BoardMember
        {
            User = DefaultUsers.userPat,
            KeyValue = DefaultKeyValues.Registrar,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static BoardMember bmKatieMalone = new BoardMember
        {
            User = DefaultUsers.userKatie,
            KeyValue = DefaultKeyValues.PublicRelations,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static BoardMember bmDerekPeterson = new BoardMember
        {
            User = DefaultUsers.userDerek,
            KeyValue = DefaultKeyValues.EquipmentManager,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };
    }
}