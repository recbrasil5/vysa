using System;
using System.Collections.Generic;
using System.Linq;
using VYSA.Domain.Abstract;
using VYSA.Domain.Concrete;
using VYSA.Domain.Entities;

namespace VYSA.WebApi.Services
{
    public class TeamCoachService
    {
        private readonly UnitOfWork _unitOfWork;

        public TeamCoachService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }

        public IEnumerable<TeamCoach> GetTeamCoaches(int teamId)
        {
            return _unitOfWork.TeamCoachRepository.Get(e => e.IsActive && e.TeamId == teamId);
        }

        public IEnumerable<Int32> GetActiveTeamCoachIdList(ICollection<TeamCoach> teamCoaches)
        {
            var list = new List<Int32>();
            if (teamCoaches != null)
            {
                teamCoaches.ToList().ForEach(x =>  { if (x.IsActive) list.Add(x.CoachId); });
            }
            return list;
        }

        public void UpdateTeamCoaches(int teamId, List<Int32> coachIdList, string lastUpdateBy)
        {
            var addList = new List<TeamCoach>();

            var existingRecords = GetTeamCoaches(teamId);
            var softDeleteList = existingRecords.Where(x => !coachIdList.Contains(x.CoachId)).ToList();

            var existingTeamCoachIdList = existingRecords.Select(x => x.CoachId);

            //build addLIst
            coachIdList.Where(x => !existingTeamCoachIdList.Contains(x))
                .ToList().ForEach(x => addList.Add(new TeamCoach
                                                   {
                                                       TeamId = teamId,
                                                       CoachId = x,
                                                       IsActive = true,
                                                       CreatedBy = lastUpdateBy,
                                                       CreatedDateUtc = DateTime.UtcNow,
                                                       LastUpdateBy = lastUpdateBy,
                                                       LastUpdateUtc = DateTime.UtcNow
                                                   }));

            //perform soft delete
            softDeleteList.ForEach(x => 
            { 
                x.IsActive = false;
                x.LastUpdateUtc = DateTime.UtcNow;
                x.LastUpdateBy = lastUpdateBy;
                _unitOfWork.TeamCoachRepository.Update(x);
            });

            //add
            addList.ForEach(x => _unitOfWork.TeamCoachRepository.Insert(x));
        }

        //public void DeleteTeamCoaches(int teamId)
        //{
        //    var existingRecords = GetTeamCoaches(teamId).ToList();
        //    foreach(var r in existingRecords)
        //    {
        //        r.IsActive = false;
        //        r.LastUpdateUtc = DateTime.UtcNow;
        //    }
        //}
    }
}