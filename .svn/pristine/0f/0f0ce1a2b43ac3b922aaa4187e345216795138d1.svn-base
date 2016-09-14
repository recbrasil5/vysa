using System;
using System.ComponentModel.DataAnnotations;
using VYSA.Domain.Entities;
using VYSA.Domain.Extensions;

namespace VYSA.WebApi.Models.Resource
{
    public class AnnouncementResourceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title Required.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Message Required.")]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [Required(ErrorMessage = "From Date Required.")]
        [Display(Name = "From")]
        [DataType(DataType.Date)]
        public DateTime From { get; set; }

        [Required(ErrorMessage = "To Date Required.")]
        [Display(Name = "To")]
        [DataType(DataType.Date)]
        public DateTime To { get; set; }
    }

    public static class AnnouncementExtensions
    {
        public static Announcement PopulateEntityWithResourceModel(this Announcement announcement, AnnouncementResourceModel resourceModel, string lastUpdateBy, bool onCreate)
        {
            announcement.Id = resourceModel.Id;
            announcement.Title = resourceModel.Title;
            announcement.Message = resourceModel.Message;
            announcement.StartTime = resourceModel.From.AbsoluteStart();
            announcement.EndTime = resourceModel.To.AbsoluteEnd();
            announcement.IsActive = true;
            announcement.LastUpdateBy = lastUpdateBy;
            announcement.LastUpdateUtc = DateTime.UtcNow;
            
            if (onCreate)
            {
                announcement.CreatedBy = lastUpdateBy;
                announcement.CreatedDateUtc = DateTime.UtcNow;
            }

            return announcement;

        }

        public static AnnouncementResourceModel ConvertToResourceModel(this Announcement announcement)
        {
            return new AnnouncementResourceModel
            {
                Id = announcement.Id,
                Title = announcement.Title,
                Message = announcement.Message,
                From = announcement.StartTime.Value,
                To = announcement.EndTime.Value
            };
        }
    }
}