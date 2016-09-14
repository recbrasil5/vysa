using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VYSA.Domain.Abstract;
using VYSA.Domain.Entities;
using VYSA.Domain.Enums;
using VYSA.Domain.Extensions;
using VYSA.WebApi.Services;

namespace VYSA.WebApi.Models.Resource
{
    public class PlayerListViewResourceModel
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Guardians { get; set; }
    }
    
    public class PlayerResourceModel
    {
        public int Id { get; set; }
        public int Age { get; set; }

        private Enums.Gender gender;
        public Enums.Gender Gender
        {
            get
            {
                gender = GenderStr.ToEnum<Enums.Gender>();
                return gender;
            }
            set { gender = value; }
        }

        [Required(ErrorMessage = "Gender Required.")]
        [Display(Name = "Gender")]
        public string GenderStr { get; set; }

        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        public IEnumerable<PlayerGuardianResourceModel> Guardians { get; set; }

    }

    public static class PlayerExtensions
    {
        public static Player PopulateEntityWithResourceModel(this Player player, PlayerResourceModel resourceModel, string lastUpdateBy, bool onCreate)
        {
            player.Id = resourceModel.Id;
            player.Gender = resourceModel.Gender;
            player.FirstName = resourceModel.FirstName;
            player.LastName = resourceModel.LastName;
            player.DateOfBirth = resourceModel.DateOfBirth;
            player.IsActive = true;
            player.LastUpdateBy = lastUpdateBy;
            player.LastUpdateUtc = DateTime.UtcNow;

            if (onCreate)
            {
                player.CreatedBy = lastUpdateBy;
                player.CreatedDateUtc = DateTime.UtcNow;
            }

            return player;
        }

        public static PlayerResourceModel ConvertToResourceModel(this Player player, IUnitOfWork _unitOfWork)
        {
            var playerDto =  new PlayerResourceModel
            {
                Id = player.Id,
                Gender = player.Gender,
                GenderStr = player.Gender.ToString(),
                FullName = player.FirstName + " " + player.LastName,
                FirstName = player.FirstName,
                LastName = player.LastName,
                DateOfBirth = player.DateOfBirth,
                Age = player.DateOfBirth.CalculateAge(),
                Guardians = new PlayerGuardianService(_unitOfWork).GetPlayerGuardianDtoListFromGuardianList(player.PlayerGuardians)
            };

            return playerDto;
        }        

        public static PlayerListViewResourceModel ConvertToListViewPlayerResourceModel(this Player player, IUnitOfWork _unitOfWork)
        {
            var listViewPlayerModel = new PlayerListViewResourceModel
            {
                Id = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                DateOfBirth = player.DateOfBirth,
                Age = player.DateOfBirth.CalculateAge()
            };

            if (player.PlayerGuardians != null)
            {
                listViewPlayerModel.Guardians = new GuardianService(_unitOfWork)
                    .GetListViewPlayerDTOGuardians(player.PlayerGuardians.Where(x => x.IsActive).Select(x => x.GuardianId).ToList());
            }

            return listViewPlayerModel;
        }

        
    }
}