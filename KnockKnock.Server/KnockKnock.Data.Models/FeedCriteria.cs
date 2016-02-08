namespace KnockKnock.Data.Models
{
    using KnockKnock.Models;

    public class FeedCriteria
    {
        public string FeedId { get; set; }

        public string FeedName { get; set; }

        public Location Location { get; set; }

        public double Radius { get; set; }
    }
}