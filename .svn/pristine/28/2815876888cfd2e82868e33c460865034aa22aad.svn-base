using System;
using System.Collections.Generic;

namespace VYSA.Domain.Entities
{
    public class Player : EntityBase
    {
        // Foreign Key
        public int? UserId { get; set; }
        // Columns
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Enums.Enums.Gender Gender { get; set; }
        public DateTime MothersDateOfBirth { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyPhone { get; set; }
        public string Doctor { get; set; }
        public string DoctorPhone { get; set; }
        //public string MedicalConditions { get; set; }

        // Navigation properties
        public virtual User User { get; set; }  //http://stackoverflow.com/questions/5668801/entity-framework-code-first-null-foreign-key
        public ICollection<Roster> Rosters { get; set; }
        public ICollection<PlayerGuardian> PlayerGuardians { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}
