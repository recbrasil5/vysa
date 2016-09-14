using System.Collections.Generic;

namespace VYSA.Domain.Entities
{
    public class Field : EntityBase
    {
        // Foreign Key
        public int LocationId { get; set; }

        // Columns
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

        // Navigation properties
        public Location Location { get; set; }
        //public ICollection<Match> Matches { get; set; }
        public ICollection<Practice> Practices { get; set; }
    }
}
