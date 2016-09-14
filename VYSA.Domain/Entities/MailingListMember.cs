namespace VYSA.Domain.Entities
{
    public class MailingListMember : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Subscribed { get; set; }
    }
}