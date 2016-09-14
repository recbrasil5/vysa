using System;
using System.ComponentModel.DataAnnotations;
using VYSA.Domain.Entities;
using VYSA.Domain.Extensions;

namespace VYSA.WebApi.Models.Resource
{
    public class RosteredPlayerResourceModel
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Display(Name = "Age")]
        public int Age
        {
            get
            {
                return DateOfBirth.CalculateAge();
            }
        }
    }

    public static class RosteredPlayerExtensions
    {

        public static RosteredPlayerResourceModel ConvertToResourceModel(this Roster roster, PlayerResourceModel playerDto)
        {
            return new RosteredPlayerResourceModel
            {
                Id = roster.Id,
                TeamId = roster.TeamId,
                PlayerId = roster.PlayerId,
                FullName = playerDto.FirstName + " " + playerDto.LastName,
                DateOfBirth = playerDto.DateOfBirth
            };
        }
    }
}