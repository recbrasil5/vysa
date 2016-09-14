using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VYSA.Domain.Entities;

namespace VYSA.WebApi.Infrastructure.Seed
{
    public class DefaultMailingListMembers
    {
        private const string lastUpdateBy = "VYSA.WebApi.Infrastructure";

        public static List<MailingListMember> MailingList = new List<MailingListMember> 
        {
            #region members
            new MailingListMember
            {
                Name = "Bill Turner",
                Email = "bill@mail.com",
                Subscribed = true,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },new MailingListMember
            {
                Name = "Jill Turner",
                Email = "jill@mail.com",
                Subscribed = true,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new MailingListMember
            {
                Name = "Phill Turner",
                Email = "phill@mail.com",
                Subscribed = true,
                IsActive = true,
                CreatedBy = lastUpdateBy,
                LastUpdateBy = lastUpdateBy,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdateUtc = DateTime.UtcNow
            },
            new MailingListMember
            {
                Name = "Will Turner",
                Email = "will@mail.com",
                Subscribed = true,
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