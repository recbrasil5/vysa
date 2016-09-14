using System;
using System.ComponentModel.DataAnnotations;
using VYSA.Domain.Entities;

namespace VYSA.WebApi.Models.Resource
{
    public class MailingListMemberResourceModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public bool Subscribed { get; set; }
    }

    public static class MailingListMemberExtensions
    {
        public static MailingListMember UpdateValuesFromDTO(this MailingListMember member, MailingListMemberResourceModel memberInView, string lastUpdateBy, bool onCreate)
        {
            member.Id = memberInView.Id;
            member.Name = memberInView.Name;
            member.Email = memberInView.Email;
            
            member.IsActive = true;
            member.LastUpdateBy = lastUpdateBy;
            member.LastUpdateUtc = DateTime.UtcNow;

            if (onCreate)
            {
                member.Subscribed = true; //always true onCreate()...
                member.CreatedBy = lastUpdateBy;
                member.CreatedDateUtc = DateTime.UtcNow;
            }
            else
            {
                member.Subscribed = memberInView.Subscribed;
            }

            return member;
        }

        public static MailingListMemberResourceModel ConvertToDto(this MailingListMember member)
        {
            return new MailingListMemberResourceModel
            {
                Id = member.Id,
                Name = member.Name,
                Email = member.Email,
                Subscribed = member.Subscribed
            };
        }
    }
}