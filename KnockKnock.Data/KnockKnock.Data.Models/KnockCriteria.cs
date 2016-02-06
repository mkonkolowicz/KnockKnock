namespace KnockKnock.Data.Models
{
    using KnockKnock.Models;

    public class KnockCriteria
    {
        public string FeedId { get; set; }

        public Location Location { get; set; }

        public double Radius { get; set; }
    }
}