using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VYSA.Domain.Entities
{
    public class Type : EntityBase
    {
        public Type()
        {
            Users = new HashSet<User>();
        }

        [MaxLength(50)]
        public string Name { get; set; }

        //Navigation Properties
        public virtual ICollection<User> Users { get; set; } //many-to-many
    }
}
