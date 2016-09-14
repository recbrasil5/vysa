using System;
using System.ComponentModel.DataAnnotations;
using VYSA.Domain.Entities;

namespace VYSA.WebApi.Models.Resource
{
    public class GuardianResourceModel
    {
        public int Id { get; set; }

        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        //public IEnumerable<PlayerGuardianDTO> Players { get; set; }
    }

    public static class GuardianExtensions
    {
        public static Guardian PopulateEntityWithResourceModel(this Guardian guardian, GuardianResourceModel resourceModel, string lastUpdateBy, bool onCreate)
        {
            guardian.Id = resourceModel.Id;
            guardian.FirstName = resourceModel.FirstName;
            guardian.LastName = resourceModel.LastName;
            //guardian.Relationship = guardianInView.Relationship;
            guardian.Phone = resourceModel.Phone;
            guardian.Email = resourceModel.Email;
            guardian.IsActive = true;
            guardian.LastUpdateBy = lastUpdateBy;
            guardian.LastUpdateUtc = DateTime.UtcNow;

            if (onCreate)
            {
                guardian.CreatedBy = lastUpdateBy;
                guardian.CreatedDateUtc = DateTime.UtcNow;
            }

            return guardian;
        }

        public static GuardianResourceModel ConvertToResourceModel(this Guardian guardian)
        {
            return new GuardianResourceModel
            {
                Id = guardian.Id,
                FirstName = guardian.FirstName,
                LastName = guardian.LastName,
                //RelationshipStr = guardian.Relationship.ToString(),
                Phone = guardian.Phone,
                Email = guardian.Email
            };
        }
    }
}