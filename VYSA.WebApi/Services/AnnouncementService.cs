using System;
using System.Collections.Generic;
using System.Linq;
using VYSA.Domain.Abstract;
using VYSA.Domain.Concrete;
using VYSA.Domain.Entities;
using VYSA.WebApi.Models.Resource;

namespace VYSA.WebApi.Services
{
    public class AnnouncementService
    {
        const int maxAnnouncements = 5;
        private readonly UnitOfWork _unitOfWork;

        public AnnouncementService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }

        public IEnumerable<Announcement> GetAnnouncements(bool adminLoad)
        {
            //on adminLoad don't perform the DateTime check - display all announcements no matter what
            var announcements = adminLoad ? 
                _unitOfWork.AnnouncementRepository.Get(a => a.IsActive)
                : _unitOfWork.AnnouncementRepository.Get(a => a.IsActive && DateTime.Compare(a.EndTime.Value, DateTime.Now) > 0);

            return announcements != null ? announcements.Where(a => a.StartTime.HasValue).OrderByDescending(a => a.StartTime.Value)
                                                        .Take(announcements.Count() > maxAnnouncements ? maxAnnouncements : announcements.Count())
                                          : new List<Announcement>();
        }

        public IEnumerable<AnnouncementResourceModel> GetAnnouncementResourceModels(bool adminLoad)
        {
            var list = new List<AnnouncementResourceModel>();
            var announcements = GetAnnouncements(adminLoad).ToList();
            announcements.ForEach(x => list.Add(x.ConvertToResourceModel()));
            return list;
        }

        public AnnouncementResourceModel GetAnnouncement(int id)
        {
            var announcement = _unitOfWork.AnnouncementRepository.GetByID(id);
            return announcement == null ? null : announcement.ConvertToResourceModel();
        }

        public AnnouncementResourceModel UpdateAnnouncement(AnnouncementResourceModel updatedAnnouncementDto, string lastUpdateBy)
        {
            var announcement = _unitOfWork.AnnouncementRepository.GetByID(updatedAnnouncementDto.Id);
            if (announcement == null) return null;

            //do update
            announcement.PopulateEntityWithResourceModel(updatedAnnouncementDto, lastUpdateBy, false);

            _unitOfWork.AnnouncementRepository.Update(announcement);
            _unitOfWork.Save();

            return updatedAnnouncementDto;
        }

        public AnnouncementResourceModel AddAnnouncement(AnnouncementResourceModel newAnnouncementDto, string lastUpdateBy)
        {
            Announcement announcement = new Announcement().PopulateEntityWithResourceModel(newAnnouncementDto, lastUpdateBy, true);
            _unitOfWork.AnnouncementRepository.Insert(announcement);
            _unitOfWork.Save();

            return announcement.ConvertToResourceModel();
        }

        public AnnouncementResourceModel SoftDeleteAnnouncement(int id, string lastUpdateBy)
        {
            var announcement = _unitOfWork.AnnouncementRepository.GetByID(id);
            if (announcement == null) return null;

            announcement.IsActive = false;
            announcement.LastUpdateUtc = DateTime.UtcNow;
            announcement.LastUpdateBy = lastUpdateBy;
            _unitOfWork.AnnouncementRepository.Update(announcement);
            _unitOfWork.Save();

            return announcement.ConvertToResourceModel();
        }
    }
}