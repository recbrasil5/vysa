using System;
using System.Collections.Generic;
using VYSA.Domain.Entities;

namespace VYSA.WebApi.Infrastructure.Seed
{
    public static class DefaultRoles
    {
        private const string lastUpdateBy = "VYSA.WebApi.Infrastructure";

        public static Role AdminRole = new Role
        {
            Name = "Admin",
            Permissions = new List<Permission>(){ DefaultPermissions.ViewAdminLinkPermission },
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Role SuperAdminRole = new Role
        {
            Name = "SuperAdmin",
            Permissions = new List<Permission>() { DefaultPermissions.ViewAdminLinkPermission },
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static Role MemberRole = new Role
        {
            Name = "Member",
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };
    }
}