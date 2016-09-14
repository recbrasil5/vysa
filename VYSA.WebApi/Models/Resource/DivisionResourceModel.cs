using System;
using System.ComponentModel.DataAnnotations;
using VYSA.Domain.Entities;
using VYSA.Domain.Enums;
using VYSA.Domain.Extensions;
using VYSA.WebApi.Models.ViewModel;

namespace VYSA.WebApi.Models.Resource
{
    public class DivisionResourceModel
    {
        public int Id { get; set; }

        public string DisplayName
        {
            get { return String.Format("U{0} {1}", AgeLimit.ToString(), GenderCode.ToString()); }
        }

        [Required]
        [Display(Name = "Age Limit")]
        public int AgeLimit { get; set; }

        private Enums.GenderCode genderCode;
        public Enums.GenderCode GenderCode
        {
            get
            {
                genderCode = GenderCodeStr.ToEnum<Enums.GenderCode>();
                return genderCode;
            }
            set { genderCode = value; }
        }
        //public ICollection<Registration> Registrations { get; set; }

        [Required(ErrorMessage = "GenderCode Required.")]
        [Display(Name = "GenderCode")]
        public string GenderCodeStr { get; set; }

    }

    public static class DivisionExtensions
    {
        public static Division PopulateEntityWithResourceModel(this Division division, DivisionResourceModel resourceModel, string lastUpdateBy, bool onCreate)
        {
            division.Id = resourceModel.Id;
            division.AgeLimit = resourceModel.AgeLimit;
            division.GenderCode = resourceModel.GenderCode;
            division.IsActive = true;
            division.LastUpdateBy = lastUpdateBy;
            division.LastUpdateUtc = DateTime.UtcNow;

            if (onCreate)
            {
                division.CreatedBy = lastUpdateBy;
                division.CreatedDateUtc = DateTime.UtcNow;
            }

            return division;
        }

        public static DivisionResourceModel ConvertToResourceModel(this Division division)
        {
            return new DivisionResourceModel
            {
                Id = division.Id,
                AgeLimit = division.AgeLimit,
                GenderCode = division.GenderCode,
                GenderCodeStr = division.GenderCode.ToString()
            };
        }

        public static DropdownItemViewModel ConvertToDropdownItemVM(this Division division)
        {
            return division.ConvertToResourceModel().ConvertToDropdownItemVMFromDivisionDto();
        }

        private static DropdownItemViewModel ConvertToDropdownItemVMFromDivisionDto(this DivisionResourceModel divisionDto)
        {
            return new DropdownItemViewModel
            {
                Id = divisionDto.Id,
                Label = String.Format("U{0} {1}", divisionDto.AgeLimit.ToString(), divisionDto.GenderCode.ToString())
            };
        }
    }
}