using System.Collections.Generic;

namespace VYSA.Domain.Entities
{
    public class Location : EntityBase
    {
        // Columns
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Note { get; set; }

        // Navigation properties
        public ICollection<Field> Fields { get; set; }
    }
}
