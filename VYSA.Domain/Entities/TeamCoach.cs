namespace VYSA.Domain.Entities
{
    public class TeamCoach : EntityBase
    {
        public int TeamId { get; set; }
        public int CoachId { get; set; }

        // Navigation properties
        public Team Team { get; set; }
        public Coach Coach { get; set; }
    }
}
