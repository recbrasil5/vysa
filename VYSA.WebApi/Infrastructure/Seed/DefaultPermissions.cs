using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VYSA.Domain.Entities;

namespace VYSA.WebApi.Infrastructure.Seed
{
    public class DefaultPermissions
    {
        private const string lastUpdateBy = "VYSA.WebApi.Infrastructure";

        public static Permission ViewAdminLinkPermission = new Permission
        {
            Name = "ViewAdminLink",
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };
    }
}