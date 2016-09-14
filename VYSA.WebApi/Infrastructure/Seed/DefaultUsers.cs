using System;
using System.Collections.Generic;
using VYSA.Domain.Entities;
using VYSA.Domain.Cryptography;
using Type = VYSA.Domain.Entities.Type;

namespace VYSA.WebApi.Infrastructure.Seed
{
    public static class DefaultUsers
    {
        private const string lastUpdateBy = "VYSA.WebApi.Infrastructure";

        public static User debugMe = new User
        {
            Username = "recbrasil5@gmail.com",
            Email = "recbrasil5@gmail.com",
            FirstName = "Nick",
            LastName = "Turner",
            PasswordHash = PasswordHash.CreateHash("pw"),
            Roles = new List<Role>() { DefaultRoles.SuperAdminRole },
            Types = new List<Type>() { DefaultTypes.CoachUserType },
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static User userMe = new User
        {
            Username = "recbrasil5@gmail.com",
            Email = "recbrasil5@gmail.com",
            FirstName = "Nick",
            LastName = "Turner",
            PasswordHash = PasswordHash.CreateHash("nike0584"),
            Roles = new List<Role>() { DefaultRoles.AdminRole },
            Types = new List<Type>() { DefaultTypes.CoachUserType },
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static User userAl = new User
        {
            Username = "allan.j.hanson@gmail.com",
            Email = "allan.j.hanson@gmail.com",
            FirstName = "Al",
            LastName = "Hanson",
            PasswordHash = PasswordHash.CreateHash("ahanson_v2015!"),
            Roles = new List<Role>() { DefaultRoles.AdminRole },
            Types = new List<Type>() { DefaultTypes.CoachUserType, DefaultTypes.GuardianUserType },
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static User userAndy = new User
        {
            Username = "andrew.olson@centurylink.com",
            Email = "andrew.olson@centurylink.com",
            FirstName = "Andrew",
            LastName = "Olson",
            PasswordHash = PasswordHash.CreateHash("aolson_v2015!"),
            Roles = new List<Role>() { DefaultRoles.AdminRole },
            Types = new List<Type>() { DefaultTypes.CoachUserType, DefaultTypes.GuardianUserType },
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static User userBruce = new User
        {
            Username = "bruce@lacrossemail.com",
            Email = "bruce@lacrossemail.com",
            FirstName = "Bruce",
            LastName = "Waldron",
            PasswordHash = PasswordHash.CreateHash("bwaldron_v2015!"),
            Roles = new List<Role>() { DefaultRoles.AdminRole },
            Types = new List<Type>() { DefaultTypes.CoachUserType, DefaultTypes.GuardianUserType },
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static User userTara = new User
        {
            Username = "timothyrieck@msn.com",
            Email = "timothyrieck@msn.com",
            FirstName = "Tim",
            LastName = "Rieck",
            PasswordHash = PasswordHash.CreateHash("trieck_v2015!"),
            Roles = new List<Role>() { DefaultRoles.AdminRole },
            Types = new List<Type>() { DefaultTypes.CoachUserType, DefaultTypes.GuardianUserType, DefaultTypes.ParentRepUserType },
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static User userStacey = new User
        {
            Username = "Fosterstace1979@yahoo.com",
            Email = "Fosterstace1979@yahoo.com",
            FirstName = "Stacey",
            LastName = "Foster",
            PasswordHash = PasswordHash.CreateHash("sfoster_v2015!"),
            Roles = new List<Role>() { DefaultRoles.AdminRole },
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static User userSteve = new User
        {
            Username = "solson@mchughexcavating.com",
            Email = "solson@mchughexcavating.com",
            FirstName = "Steve",
            LastName = "Olson",
            PasswordHash = PasswordHash.CreateHash("solson_v2015!"),
            Roles = new List<Role>() { DefaultRoles.AdminRole },
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static User userPat = new User
        {
            Username = "patrick.rotering@gmail.com",
            Email = "patrick.rotering@gmail.com",
            FirstName = "Patrick",
            LastName = "Rotering",
            PasswordHash = PasswordHash.CreateHash("protering_v2015!"),
            Roles = new List<Role>() { DefaultRoles.AdminRole },
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static User userKatie = new User
        {
            Username = "laesunmarie@yahoo.com",
            Email = "laesunmarie@yahoo.com",
            FirstName = "Katie",
            LastName = "Malone",
            PasswordHash = PasswordHash.CreateHash("kmalone_v2015!"),
            Roles = new List<Role>() { DefaultRoles.AdminRole },
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static User userShannon = new User
        {
            Username = "markandshop@yahoo.com",
            Email = "markandshop@yahoo.com",
            FirstName = "Shannon",
            LastName = "Schneider",
            PasswordHash = PasswordHash.CreateHash("sschneider_v2015!"),
            Roles = new List<Role>() { DefaultRoles.AdminRole },
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static User userDerek = new User
        {
            Username = "deekpowers@hotmail.com",
            Email = "deekpowers@hotmail.com",
            FirstName = "Derek",
            LastName = "Peterson",
            PasswordHash = PasswordHash.CreateHash("dpeterson_v2015!"),
            Roles = new List<Role>() { DefaultRoles.AdminRole },
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static User userAndyMeyer = new User
        {
            Username = "andy@netkinetix.com",
            Email = "andy@netkinetix.com",
            FirstName = "Andy",
            LastName = "Meyer",
            PasswordHash = PasswordHash.CreateHash("andy_v2015!"),
            Roles = new List<Role>() { DefaultRoles.AdminRole },
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };
        
    }
}