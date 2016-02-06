namespace KnockKnock.Data.Indexes
{
    using System.Linq;

    using Raven.Client.Indexes;

    using KnockKnock.Models;

    internal sealed class Feed_ByLocationAndName : AbstractIndexCreationTask<Feed>
    {
        public Feed_ByLocationAndName()
        {
            Map = feeds => feeds.Select(feed => new { _ = SpatialGenerate(nameof(Location), feed.Location.Latitude, feed.Location.Longitude), Name = feed.Name });
        }
    }
}