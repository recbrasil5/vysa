﻿using System.Collections.Generic;

namespace VYSA.Domain.Entities
{
    public class Team : EntityBase
    {
        // Foreign Keys
        public int SeasonId { get; set; }
        public int DivisionId { get; set; }

        // Columns
        public string Name { get; set; }
        public decimal Cost { get; set; }

        // Navigation properties
        public Season Season { get; set; }
        public Division Division { get; set; }
        public ICollection<Roster> Rosters { get; set; }
        public ICollection<TeamEvent> TeamEvents { get; set; }
        public ICollection<TeamCoach> TeamCoaches { get; set; }
        public ICollection<TeamParentRep> TeamParentReps { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}
