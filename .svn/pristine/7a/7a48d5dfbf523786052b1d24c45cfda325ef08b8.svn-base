using System.Collections.Generic;

namespace VYSA.Domain.Entities
{
    public class Coach : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Navigation properties
        public ICollection<TeamCoach> TeamCoaches { get; set; }
    }
}
