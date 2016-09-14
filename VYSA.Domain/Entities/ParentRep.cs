﻿using System.Collections.Generic;

namespace VYSA.Domain.Entities
{
    public class ParentRep : EntityBase
    {
        // Columns
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Navigation properties
        public User User { get; set; }
        public ICollection<TeamParentRep> TeamParentReps { get; set; }

        
    }
}