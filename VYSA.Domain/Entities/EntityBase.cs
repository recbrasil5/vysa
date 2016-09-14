using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VYSA.Domain.Entities
{
    public abstract class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime LastUpdateUtc { get; set; }
        public string LastUpdateBy { get; set; }
    }
}
