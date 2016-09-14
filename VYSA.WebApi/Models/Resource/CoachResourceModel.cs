using System;
using System.ComponentModel.DataAnnotations;
using VYSA.Domain.Entities;

namespace VYSA.WebApi.Models.Resource
{
    public class CoachResourceModel
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

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

    }

    public static class CoachExtensions
    {
        public static Coach PopulateEntityWithResourceModel(this Coach coach, CoachResourceModel resourceModel, string lastUpdateBy, bool onCreate)
        {
            coach.Id = resourceModel.Id;
            coach.FirstName = resourceModel.FirstName;
            coach.LastName = resourceModel.LastName;
            coach.Email = resourceModel.Email;
            coach.Phone = resourceModel.Phone;
            coach.IsActive = true;
            coach.LastUpdateBy = lastUpdateBy;
            coach.LastUpdateUtc = DateTime.UtcNow;

            if (onCreate)
            {
                coach.CreatedBy = lastUpdateBy;
                coach.CreatedDateUtc = DateTime.UtcNow;
            }

            return coach;
        }

        public static CoachResourceModel ConvertToResourceModel(this Coach coach)
        {
            return new CoachResourceModel
            {
                Id = coach.Id,
                FirstName = coach.FirstName,
                LastName = coach.LastName,
                Email = coach.Email,
                Phone = coach.Phone
            };
        }
    }
}