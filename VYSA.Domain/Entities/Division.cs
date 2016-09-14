using System.Collections.Generic;

namespace VYSA.Domain.Entities
{
    public class Division : EntityBase
    {
        // Columns
        public int AgeLimit { get; set; }
        public Enums.Enums.GenderCode GenderCode { get; set; }

        // Navigation properties
        public ICollection<Team> Teams { get; set; }
    }
}
