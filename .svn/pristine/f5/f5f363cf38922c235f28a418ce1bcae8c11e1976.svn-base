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
    public class CoachService
    {
        private readonly UnitOfWork _unitOfWork;

        public CoachService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }

        public IEnumerable<CoachResourceModel> GetCoachResourceModels()
        {
            var list = new List<CoachResourceModel>();
            _unitOfWork.CoachRepository.Get(a => a.IsActive).ToList()
                        .ForEach(x => list.Add(x.ConvertToResourceModel()));
            return list;
        }

        public IEnumerable<MailingListResourceModel> GetMailingList()
        {
            return _unitOfWork.CoachRepository.Get(b => b.IsActive)
                .Select(x => new MailingListResourceModel
                {
                    Name = string.Format("{0} {1}", x.FirstName, x.LastName),
                    Email = x.Email
                });
        }

        public IEnumerable<DropdownItemViewModel> GetCoachDropdownVMs()
        {
            var coachList = _unitOfWork.CoachRepository.Get(a => a.IsActive);
            var list = new List<DropdownItemViewModel>();
            coachList.ToList().ForEach(x => list.Add(new DropdownItemViewModel
                                                       {
                                                           Id = x.Id,
                                                           Label = x.FirstName + " " + x.LastName
                                                       }));
            return list;
        }

        public CoachResourceModel GetCoach(int id)
        {
            var coach = _unitOfWork.CoachRepository.GetByID(id);
            return coach == null ? null : coach.ConvertToResourceModel();
        }

        public CoachResourceModel UpdateCoach(CoachResourceModel updatedCoachDto, string lastUpdateBy)
        {
            var coach = _unitOfWork.CoachRepository.GetByID(updatedCoachDto.Id);
            if (coach == null) return null;

            //do update
            coach.PopulateEntityWithResourceModel(updatedCoachDto, lastUpdateBy, false);

            _unitOfWork.CoachRepository.Update(coach);
            _unitOfWork.Save();

            return updatedCoachDto;
        }

        public CoachResourceModel AddCoach(CoachResourceModel newCoachDto, string lastUpdateBy)
        {
            Coach coach = new Coach().PopulateEntityWithResourceModel(newCoachDto, lastUpdateBy, true);
            _unitOfWork.CoachRepository.Insert(coach);
            _unitOfWork.Save();

            return coach.ConvertToResourceModel();
        }

        public CoachResourceModel SoftDeleteCoach(int id, string lastUpdateBy)
        {
            var coach = _unitOfWork.CoachRepository.GetByID(id);
            if (coach == null) return null;

            coach.IsActive = false;
            coach.LastUpdateUtc = DateTime.UtcNow;
            coach.LastUpdateBy = lastUpdateBy;
            _unitOfWork.CoachRepository.Update(coach);
            _unitOfWork.Save();

            return coach.ConvertToResourceModel();
        }
    }
}