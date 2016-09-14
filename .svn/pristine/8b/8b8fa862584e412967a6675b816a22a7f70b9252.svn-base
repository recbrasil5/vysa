using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VYSA.Domain.Entities;

namespace VYSA.WebApi.Models.Resource
{
    public class RosterResourceModel
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
    }

    public static class RosterExtensions
    {
        public static Roster UpdateValuesFromDTO(this Roster roster, RosterResourceModel rosterDto, string lastUpdateBy, bool onCreate)
        {
            roster.Id = rosterDto.Id;
            roster.TeamId = rosterDto.TeamId;
            roster.PlayerId = rosterDto.PlayerId;
            roster.IsActive = true;
            roster.LastUpdateBy = lastUpdateBy;
            roster.LastUpdateUtc = DateTime.UtcNow;

            if (onCreate)
            {
                roster.CreatedBy = lastUpdateBy;
                roster.CreatedDateUtc = DateTime.UtcNow;
            }

            return roster;
        }

        public static RosterResourceModel ConvertToDto(this Roster roster)
        {
            return new RosterResourceModel
            {
                Id = roster.Id,
                TeamId = roster.TeamId,
                PlayerId = roster.PlayerId
            };
        }

    }
}