using System;
using System.Collections.Generic;

namespace VYSA.Domain.Entities
{
    public class Season : EntityBase
    {
        // Columns
        public Enums.Enums.SeasonType SeasonType { get; set; }
        public int Year { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Event> Events { get; set; }
        public ICollection<Team> Teams { get; set; } 
    }
}
