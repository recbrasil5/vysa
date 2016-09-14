using System;
using System.ComponentModel.DataAnnotations;
using VYSA.Domain.Entities;
using VYSA.Domain.Enums;
using VYSA.Domain.Extensions;

namespace VYSA.WebApi.Models.Resource
{
    public class PlayerGuardianResourceModel
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int GuardianId { get; set; }

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

        private Enums.Relationship relationship;
        public Enums.Relationship Relationship
        {
            get
            {
                relationship = RelationshipStr.ToEnum<Enums.Relationship>();
                return relationship;
            }
            set { relationship = value; }
        }

        [Required(ErrorMessage = "Relationship Required.")]
        [Display(Name = "Relationship")]
        public string RelationshipStr { get; set; }

    }


    public static class PlayerGuardianExtensions
    {
        public static PlayerGuardian PopulateEntityWithResourceModel(this PlayerGuardian playerGuardian, PlayerGuardianResourceModel resourceModel, string lastUpdateBy, bool onCreate)
        {
            playerGuardian.Id = resourceModel.Id;
            playerGuardian.Relationship = resourceModel.Relationship; //we'll only ever edit the relationship b/t player and guardian 
            playerGuardian.IsActive = true;
            playerGuardian.LastUpdateBy = lastUpdateBy;
            playerGuardian.LastUpdateUtc = DateTime.UtcNow;

            if (onCreate)
            {
                //only on creation are these set.
                playerGuardian.PlayerId = resourceModel.PlayerId;
                playerGuardian.GuardianId = resourceModel.GuardianId;

                playerGuardian.CreatedBy = lastUpdateBy;
                playerGuardian.CreatedDateUtc = DateTime.UtcNow;
            }

            return playerGuardian;
        }

        public static PlayerGuardianResourceModel ConvertToResourceModel(this PlayerGuardian playerGuardian, GuardianResourceModel guardianDto)
        {
            var playerGuardianDto = new PlayerGuardianResourceModel
            {
                Id = playerGuardian.Id,
                PlayerId = playerGuardian.PlayerId,
                GuardianId = playerGuardian.GuardianId,
                Relationship = playerGuardian.Relationship,
                RelationshipStr = playerGuardian.Relationship.ToString(),
                FirstName = guardianDto.FirstName,
                LastName = guardianDto.LastName,
                Email = guardianDto.Email,
                Phone = guardianDto.Phone
            };

            return playerGuardianDto;
        }
        
    }
}