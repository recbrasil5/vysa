namespace VYSA.Domain.Entities
{
    public class PlayerGuardian : EntityBase
    {
        // Foreign Key
        public int PlayerId { get; set; }
        public int GuardianId { get; set; }
        public Enums.Enums.Relationship Relationship { get; set; }

        // Navigation properties
        public Player Player { get; set; }
        public Guardian Guardian { get; set; }
    }
}
