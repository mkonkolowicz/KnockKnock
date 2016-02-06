namespace KnockKnock.Models
{
    public class Knock : EntityBase
    {
        public string FeedId { get; set; }

        public byte[] Content { get; set; }

        public string Message { get; set; }
        
        public Location Location { get; set; }
    }
}