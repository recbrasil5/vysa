using System;
using System.ComponentModel.DataAnnotations;
using VYSA.Domain.Entities;

namespace VYSA.WebApi.Models.Resource
{
    public class EventListViewSimpleResourceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string DateRange { get; set; }
    }

    public class EventListViewResourceModel
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }

    public class EventResourceModel
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "TournamentUrl")]
        public string TournamentUrl { get; set; }

        [Display(Name = "GoogleMapUrl")]
        public string GoogleMapUrl { get; set; }

        [Required(ErrorMessage = "StartDate Required.")]
        [Display(Name = "StartDate")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDate Required.")]
        [Display(Name = "EndDate")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }

    public static class EventExtensions
    {
        public static Event PopulateEntityWithResourceModel(this Event Event, EventResourceModel resourceModel, string lastUpdateBy, bool onCreate)
        {
            Event.Id = resourceModel.Id;
            Event.SeasonId = resourceModel.SeasonId;
            Event.Name = resourceModel.Name;
            Event.City = resourceModel.City;
            Event.State = resourceModel.State;
            Event.TournamentUrl = resourceModel.TournamentUrl;
            Event.GoogleMapUrl = resourceModel.GoogleMapUrl;
            Event.StartDate = resourceModel.StartDate;
            Event.EndDate = resourceModel.EndDate;

            Event.IsActive = true;
            Event.LastUpdateBy = lastUpdateBy;
            Event.LastUpdateUtc = DateTime.UtcNow;

            if (onCreate)
            {
                Event.CreatedBy = lastUpdateBy;
                Event.CreatedDateUtc = DateTime.UtcNow;
            }

            return Event;
        }

        public static EventResourceModel ConvertToResourceModel(this Event eventEntity)
        {
            return new EventResourceModel
            {
                Id = eventEntity.Id,
                SeasonId = eventEntity.SeasonId,
                Name = eventEntity.Name,
                City =  eventEntity.City,
                State = eventEntity.State,
                TournamentUrl = eventEntity.TournamentUrl,
                GoogleMapUrl = eventEntity.GoogleMapUrl,
                StartDate = eventEntity.StartDate.Value,
                EndDate = eventEntity.EndDate.Value
            };
        }

        public static EventListViewResourceModel ConvertToEventListViewResourceModel(this Event eventEntity)
        {
            return new EventListViewResourceModel
            {
                Id = eventEntity.Id,
                SeasonId = eventEntity.SeasonId,
                Name = eventEntity.Name,
                Location = string.Format("{0}{1}", eventEntity.City, !string.IsNullOrWhiteSpace(eventEntity.State) ? ", " + eventEntity.State : ""),
                StartDate = eventEntity.StartDate.Value,
                EndDate = eventEntity.EndDate.Value
            };
        }

        public static EventListViewSimpleResourceModel ConvertToEventListViewSimpleResourceModel(this Event eventEntity)
        {
            return new EventListViewSimpleResourceModel
            {
                Id = eventEntity.Id,
                Name = eventEntity.Name,
                Location = string.Format("{0}{1}", eventEntity.City, !string.IsNullOrWhiteSpace(eventEntity.State) ? ", " + eventEntity.State : ""),
                DateRange = string.Format(@"{0}/{1}-{2}/{3}",
                                    eventEntity.StartDate.Value.Month,
                                    eventEntity.StartDate.Value.Day,
                                    eventEntity.EndDate.Value.Month,
                                    eventEntity.EndDate.Value.Day)
            };
        }
    }
}