using System;

namespace VYSA.Domain.Entities
{
    public class Practice : EntityBase
    {
        // Foreign Keys
        public int FieldId { get; set; }

        // Columns
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool? Cancelled{ get; set; }

        // Navigation properties
        public Field Field { get; set; }
        //public ICollection<Team> Teams { get; set; }
    }
}
