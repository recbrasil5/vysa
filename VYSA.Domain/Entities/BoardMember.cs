namespace VYSA.Domain.Entities
{
    public class BoardMember : EntityBase
    {
        // Foreign Keys
        public int UserId { get; set; }
        public int KeyValueId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public KeyValue KeyValue { get; set; }
    }
}
