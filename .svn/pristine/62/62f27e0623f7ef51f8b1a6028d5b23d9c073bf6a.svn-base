using System;
using System.Collections.Generic;
using System.Linq;
using VYSA.Domain.Abstract;
using VYSA.Domain.Concrete;
using VYSA.Domain.Entities;
using VYSA.WebApi.Models.Resource;
using VYSA.WebApi.Models.ViewModel;

namespace VYSA.WebApi.Services
{
    public class DivisionService
    {
        private readonly UnitOfWork _unitOfWork;

        public DivisionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }

        public IEnumerable<DropdownItemViewModel> GetDivisionDropdownVms()
        {
            var list = new List<DropdownItemViewModel>();
            var divisions = _unitOfWork.DivisionRepository
                              .Get(d => d.IsActive)
                              .OrderBy(a => a.AgeLimit).ThenBy(a => a.GenderCode).ToList();

            divisions.ForEach(d => list.Add(d.ConvertToDropdownItemVM()));
            return list;
        }

        public DivisionResourceModel GetDivision(int id)
        {
            var division = _unitOfWork.DivisionRepository.GetByID(id);
            return division == null ? null : division.ConvertToResourceModel();
        }

        public DivisionResourceModel UpdateDivision(DivisionResourceModel updatedDivisionDto, string lastUpdateBy)
        {
            var division = _unitOfWork.DivisionRepository.GetByID(updatedDivisionDto.Id);
            if (division == null) return null;

            //do update
            division.PopulateEntityWithResourceModel(updatedDivisionDto, lastUpdateBy, false);

            _unitOfWork.DivisionRepository.Update(division);
            _unitOfWork.Save();

            return updatedDivisionDto;
        }

        public DivisionResourceModel AddDivision(DivisionResourceModel newDivisionDto, string lastUpdateBy)
        {
            Division division = new Division().PopulateEntityWithResourceModel(newDivisionDto, lastUpdateBy, true);
            _unitOfWork.DivisionRepository.Insert(division);
            _unitOfWork.Save();

            return division.ConvertToResourceModel();
        }

        public DivisionResourceModel SoftDeleteDivision(int id, string lastUpdateBy)
        {
            var division = _unitOfWork.DivisionRepository.GetByID(id);
            if (division == null) return null;

            division.IsActive = false;
            division.LastUpdateUtc = DateTime.UtcNow;
            division.LastUpdateBy = lastUpdateBy;
            _unitOfWork.DivisionRepository.Update(division);
            _unitOfWork.Save();

            return division.ConvertToResourceModel();
        }
    }
}