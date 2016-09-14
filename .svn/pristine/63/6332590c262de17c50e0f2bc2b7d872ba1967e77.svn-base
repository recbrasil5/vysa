using System.Collections.Generic;

namespace VYSA.Domain.Entities
{
    public class Role : EntityBase
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string Name { get; set; }

        //Navigation Properties
        public virtual ICollection<User> Users { get; set; } //many-to-many
        public virtual ICollection<Permission> Permissions { get; set; } //many-to-many
    }
}
