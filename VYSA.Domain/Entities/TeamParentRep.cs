namespace VYSA.Domain.Entities
{
    public class TeamParentRep : EntityBase
    {
        public int TeamId { get; set; }
        public int ParentRepId { get; set; }

        // Navigation properties
        public Team Team { get; set; }
        public ParentRep ParentRep { get; set; }
    }
}
