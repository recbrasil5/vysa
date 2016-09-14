using System;
using System.Collections.Generic;
using System.Linq;
using VYSA.Domain.Abstract;
using VYSA.Domain.Concrete;
using VYSA.Domain.Entities;
using VYSA.Domain.Enums;
using VYSA.WebApi.Models.Resource;

namespace VYSA.WebApi.Services
{
    public class SeasonService
    {
        private readonly UnitOfWork _unitOfWork;

        public SeasonService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }

        public IEnumerable<SeasonResourceModel> GetSeasonDtos(Boolean seasonGridView)
        {
            var seasonDtos = new List<SeasonResourceModel>();
            var seasonEntitys = _unitOfWork.SeasonRepository.Get(a => a.IsActive).OrderByDescending(s => s.StartDate).ToList();
            seasonEntitys.ForEach(s => seasonDtos.Add(s.ConvertToResourceModel(_unitOfWork, seasonGridView)));
            return seasonDtos;
        }

        public SeasonResourceModel GetSeason(int id)
        {
            var season = _unitOfWork.SeasonRepository.GetByID(id);
            return season == null ? null : season.ConvertToResourceModel(_unitOfWork, false); //pass unitOfWork to call other Services here
        }

        public SeasonResourceModel UpdateSeason(SeasonResourceModel updatedSeasonDto, string lastUpdateBy)
        {
            var season = _unitOfWork.SeasonRepository.GetByID(updatedSeasonDto.Id);
            if (season == null) return null;

            //do update
            season.PopulateEntityWithResourceModel(updatedSeasonDto, lastUpdateBy, false);

            _unitOfWork.SeasonRepository.Update(season);
            _unitOfWork.Save();

            return updatedSeasonDto;
        }

        public SeasonResourceModel AddSeason(SeasonResourceModel newSeasonDto, string lastUpdateBy)
        {
            Season season = new Season().PopulateEntityWithResourceModel(newSeasonDto, lastUpdateBy, true);
            _unitOfWork.SeasonRepository.Insert(season);
            _unitOfWork.Save();

            return season.ConvertToResourceModel();
        }

        public SeasonResourceModel SoftDeleteSeason(int id, string lastUpdateBy)
        {
            var season = _unitOfWork.SeasonRepository.GetByID(id);
            if (season == null) return null;

            season.IsActive = false;
            season.LastUpdateUtc = DateTime.UtcNow;
            season.LastUpdateBy = lastUpdateBy;
            _unitOfWork.SeasonRepository.Update(season);
            _unitOfWork.Save();

            return season.ConvertToResourceModel();
        }

        public Boolean AlreadyExists(int year, Enums.SeasonType seasonType)
        {
            return _unitOfWork.SeasonRepository
                    .Get(x => x.IsActive)
                    .Any(x => x.Year == year && x.SeasonType == seasonType);
        }
    }
}