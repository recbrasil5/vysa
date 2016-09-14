using System;
using System.Collections.Generic;

namespace VYSA.Domain.Entities
{
    public class Permission : EntityBase
    {
        public string Name { get; set; }

        //Navigation Properties
        public virtual ICollection<Role> Roles { get; set; } //many-to-many
    }
}
