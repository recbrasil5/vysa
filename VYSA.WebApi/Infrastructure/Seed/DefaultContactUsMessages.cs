using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VYSA.Domain.Entities;

namespace VYSA.WebApi.Infrastructure.Seed
{
    public class DefaultContactUsMessages
    {
        private const string lastUpdateBy = "VYSA.WebApi.Infrastructure";

        public static ContactUsMessage JimsMessage = new ContactUsMessage
        {
            Name = "jim",
            EmailAddr = "jim@mail.com",
            Subject = "Test Email",
            Message = @"This is just a default test email from the contact us page. I think you're doing a wonderful job. Thanks!",
            Read = false,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };

        public static ContactUsMessage PamsMessage = new ContactUsMessage
        {
            Name = "pam",
            EmailAddr = "pam@mail.com",
            Subject = "Tryouts Email",
            Message = @"This email has to do with the upcoming tryouts. Where and when are they? Which season are they for? Please get back to me...
                        Thanks Alot, Pam!",
            Read = false,
            IsActive = true,
            CreatedBy = lastUpdateBy,
            LastUpdateBy = lastUpdateBy,
            CreatedDateUtc = DateTime.UtcNow,
            LastUpdateUtc = DateTime.UtcNow
        };
    }
}