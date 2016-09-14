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
    public class ParentRepService
    {
        private readonly UnitOfWork _unitOfWork;

        public ParentRepService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }

        public IEnumerable<ParentRep> GetParentReps()
        {
            return _unitOfWork.ParentRepRepository.Get(a => a.IsActive);
        }

        public IEnumerable<DropdownItemViewModel> GetParentRepDropdownVMs()
        {
            var parentRepList = _unitOfWork.ParentRepRepository.Get(a => a.IsActive);
            var list = new List<DropdownItemViewModel>();
            parentRepList.ToList().ForEach(x => list.Add(new DropdownItemViewModel
            {
                Id = x.Id,
                Label = x.FirstName + " " + x.LastName
            }));
            return list;
        }

        public ParentRepResourceModel GetParentRep(int id)
        {
            var parentRep = _unitOfWork.ParentRepRepository.GetByID(id);
            return parentRep == null ? null : parentRep.ConvertToDto();
        }

        public ParentRepResourceModel UpdateParentRep(ParentRepResourceModel updatedParentRepDto, string lastUpdateBy)
        {
            var parentRep = _unitOfWork.ParentRepRepository.GetByID(updatedParentRepDto.Id);
            if (parentRep == null) return null;

            //do update
            parentRep.UpdateValuesFromDTO(updatedParentRepDto, lastUpdateBy, false);

            _unitOfWork.ParentRepRepository.Update(parentRep);
            _unitOfWork.Save();

            return updatedParentRepDto;
        }

        public ParentRepResourceModel AddParentRep(ParentRepResourceModel newParentRepDto, string lastUpdateBy)
        {
            ParentRep parentRep = new ParentRep().UpdateValuesFromDTO(newParentRepDto, lastUpdateBy, true);
            _unitOfWork.ParentRepRepository.Insert(parentRep);
            _unitOfWork.Save();

            return parentRep.ConvertToDto();
        }

        public ParentRepResourceModel SoftDeleteParentRep(int id, string lastUpdateBy)
        {
            var parentRep = _unitOfWork.ParentRepRepository.GetByID(id);
            if (parentRep == null) return null;

            parentRep.IsActive = false;
            parentRep.LastUpdateUtc = DateTime.UtcNow;
            parentRep.LastUpdateBy = lastUpdateBy;
            _unitOfWork.ParentRepRepository.Update(parentRep);
            _unitOfWork.Save();

            return parentRep.ConvertToDto();
        }
    }
}