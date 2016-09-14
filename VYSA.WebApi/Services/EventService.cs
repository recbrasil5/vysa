using System;
using System.Collections.Generic;
using System.Linq;
using VYSA.Domain.Abstract;
using VYSA.Domain.Concrete;
using VYSA.Domain.Entities;
using VYSA.WebApi.Models.Resource;

namespace VYSA.WebApi.Services
{
    public class EventService
    {
        private readonly UnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }

        public IEnumerable<Event> GetEventsBySeasonId(int seasonId)
        {
            return _unitOfWork.EventRepository.Get(b => b.IsActive && b.SeasonId == seasonId);
        }

        public IEnumerable<EventListViewResourceModel> GetEventListViewDtos(int seasonId)
        {
            var eventListViewDtos = new List<EventListViewResourceModel>();
            var seasonEvents = _unitOfWork.EventRepository.Get(b => b.IsActive && b.SeasonId == seasonId).ToList();
            seasonEvents.ForEach(e => eventListViewDtos.Add(e.ConvertToEventListViewResourceModel()));
            return eventListViewDtos;
        }

        public IEnumerable<EventListViewSimpleResourceModel> GetEventListViewSimpleDtos(int seasonId)
        {
            var eventListViewResourceModels = new List<EventListViewSimpleResourceModel>();
            var seasonEvents = _unitOfWork.EventRepository.Get(b => b.IsActive && b.SeasonId == seasonId).ToList();
            seasonEvents.ForEach(e => eventListViewResourceModels.Add(e.ConvertToEventListViewSimpleResourceModel()));
            return eventListViewResourceModels;
        }

        public EventResourceModel GetEvent(int id)
        {
            var Event = _unitOfWork.EventRepository.GetByID(id);
            return Event == null ? null : Event.ConvertToResourceModel();
        }

        public IEnumerable<int> GetEventIdListFromSeasonId(int seasonId)
        {
            var events = _unitOfWork.EventRepository.Get(e => e.SeasonId == seasonId).Select(x => x.Id).ToList();
            return events.Any() ? events : new List<int>();
        }

        public EventResourceModel UpdateEvent(EventResourceModel updatedEventDTO, string lastUpdateBy)
        {
            var Event = _unitOfWork.EventRepository.GetByID(updatedEventDTO.Id);
            if (Event == null) return null;

            //do update
            Event.PopulateEntityWithResourceModel(updatedEventDTO, lastUpdateBy, false);

            _unitOfWork.EventRepository.Update(Event);
            _unitOfWork.Save();

            return updatedEventDTO;
        }

        public EventResourceModel AddEvent(EventResourceModel newEventDTO, string lastUpdateBy)
        {
            Event Event = new Event().PopulateEntityWithResourceModel(newEventDTO, lastUpdateBy, true);
            _unitOfWork.EventRepository.Insert(Event);
            _unitOfWork.Save();

            return Event.ConvertToResourceModel();
        }

        public EventResourceModel SoftDeleteEvent(int id, string lastUpdateBy)
        {
            var Event = _unitOfWork.EventRepository.GetByID(id);
            if (Event == null) return null;

            Event.IsActive = false;
            Event.LastUpdateUtc = DateTime.UtcNow;
            Event.LastUpdateBy = lastUpdateBy;
            _unitOfWork.EventRepository.Update(Event);
            _unitOfWork.Save();

            return Event.ConvertToResourceModel();
        }
    }
}