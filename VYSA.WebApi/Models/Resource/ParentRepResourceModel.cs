using System;
using System.ComponentModel.DataAnnotations;
using VYSA.Domain.Entities;

namespace VYSA.WebApi.Models.Resource
{
    public class ParentRepResourceModel
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

    public static class ParentRepExtensions
    {
        public static ParentRep UpdateValuesFromDTO(this ParentRep parentRep, ParentRepResourceModel parentRepInView, string lastUpdateBy, bool onCreate)
        {
            parentRep.Id = parentRepInView.Id;
            parentRep.FirstName = parentRepInView.FirstName;
            parentRep.LastName = parentRepInView.LastName;
            parentRep.Email = parentRepInView.Email;
            parentRep.Phone = parentRepInView.Phone;
            parentRep.IsActive = true;
            parentRep.LastUpdateBy = lastUpdateBy;
            parentRep.LastUpdateUtc = DateTime.UtcNow;

            if (onCreate)
            {
                parentRep.CreatedBy = lastUpdateBy;
                parentRep.CreatedDateUtc = DateTime.UtcNow;
            }

            return parentRep;
        }

        public static ParentRepResourceModel ConvertToDto(this ParentRep parentRep)
        {
            return new ParentRepResourceModel
            {
                Id = parentRep.Id,
                FirstName = parentRep.FirstName,
                LastName = parentRep.LastName,
                Email = parentRep.Email,
                Phone =  parentRep.Phone
            };
        }
    }

}