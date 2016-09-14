using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VYSA.Domain.Abstract;
using VYSA.Domain.Entities;
using VYSA.Domain.Enums;
using VYSA.Domain.Extensions;
using VYSA.WebApi.Services;

namespace VYSA.WebApi.Models.Resource
{
    public class SeasonResourceModel
    {
        public int Id { get; set; }

        #region helper code
        //public String TerminationStatus
        //{
        //    get
        //    {
        //        return TerminationStatusCodeInt.HasValue ?
        //            ((Enums.Enums.TerminationStatusCode)(TerminationStatusCodeInt.Value)).msm_GetTerminationStatusCodeName()
        //            : "Not Scheduled";
        //    }
        //}
        #endregion

        //public Int16? TerminationStatusCodeInt { get; set; }

        private Enums.SeasonType seasonType;
        public Enums.SeasonType SeasonType
        {
            get
            {
                seasonType = SeasonTypeStr.ToEnum<Enums.SeasonType>();
                return seasonType;
            }
            set { seasonType = value; }
        }
        //public ICollection<Registration> Registrations { get; set; }

        [Required(ErrorMessage = "SeasonType Required.")]
        [Display(Name = "SeasonType")]
        public string SeasonTypeStr { get; set; }

        //[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Year Required.")]
        [Display(Name = "Year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Registration Date Required.")]
        [Display(Name = "Registration Date")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Start Date Required.")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date Required.")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public IEnumerable<EventListViewResourceModel> EventList;
        public IEnumerable<TeamListViewResourceModel> TeamList;

        public Int32 Teams { get; set; }
        public Int32 RosteredPlayers { get; set; }
    }

    public static class SeasonExtensions
    {
        public static Season PopulateEntityWithResourceModel(this Season season, SeasonResourceModel resourceModel, string lastUpdateBy, bool onCreate)
        {
            season.Id = resourceModel.Id;
            season.SeasonType = resourceModel.SeasonType;
            season.Year = resourceModel.Year;
            season.RegistrationDate = resourceModel.RegistrationDate.AbsoluteStart();
            season.StartDate = resourceModel.StartDate.AbsoluteStart();
            season.EndDate = resourceModel.EndDate.AbsoluteEnd();
            season.IsActive = true;
            season.LastUpdateBy = lastUpdateBy;
            season.LastUpdateUtc = DateTime.UtcNow;

            if (onCreate)
            {
                season.CreatedBy = lastUpdateBy;
                season.CreatedDateUtc = DateTime.UtcNow;
            }

            return season;

        }

        public static SeasonResourceModel ConvertToResourceModel(this Season season)
        {
            return new SeasonResourceModel
            {
                Id = season.Id,
                Year = season.Year,
                SeasonType = season.SeasonType,
                SeasonTypeStr = season.SeasonType.ToString(),
                RegistrationDate = season.RegistrationDate,
                StartDate = season.StartDate,
                EndDate = season.EndDate
            };
        }

        public static SeasonResourceModel ConvertToResourceModel(this Season season, IUnitOfWork _unitOfWork, Boolean seasonGridView)
        {
            return seasonGridView ? new SeasonResourceModel
            {
                Id = season.Id,
                Year = season.Year,
                SeasonType = season.SeasonType,
                SeasonTypeStr = season.SeasonType.ToString(),
                RegistrationDate = season.RegistrationDate,
                StartDate = season.StartDate,
                EndDate = season.EndDate,
                Teams = new TeamService(_unitOfWork).GetTeamCountBySeasonId(season.Id),
                RosteredPlayers = new TeamService(_unitOfWork).GetRosteredPlayerCountBySeasonId(season.Id)
            }
            :

            new SeasonResourceModel
            {
                Id = season.Id,
                Year = season.Year,
                SeasonType = season.SeasonType,
                SeasonTypeStr = season.SeasonType.ToString(),
                RegistrationDate = season.RegistrationDate,
                StartDate = season.StartDate,
                EndDate = season.EndDate,
                EventList = new EventService(_unitOfWork).GetEventListViewDtos(season.Id),
                TeamList = new TeamService(_unitOfWork).GetTeamListViewDtos(season.Id)
            };
        }
    }
}