using System;
using System.Collections.Generic;

namespace VYSA.Domain.Entities
{
    public class User : EntityBase 
    {
        // Columns
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public Boolean AllowNotifications { get; set; }

        //not yet used
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
        public DateTime? LastLoginDateTimeUtc { get; set; }
        public DateTime? LastActivityDateTimeUtc { get; set; }
        public DateTime? LastPasswordChangeDateTimeUtc { get; set; }
        
        //Navigation Properties
        public virtual ICollection<Role> Roles { get; set; } //many-to-many
        public virtual ICollection<Type> Types { get; set; } //many-to-many
        public ICollection<Coach> Coaches { get; set; }
        public ICollection<ParentRep> ParentReps { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
