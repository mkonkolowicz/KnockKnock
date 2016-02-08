namespace KnockKnock.Data.Indexes
{
    using System.Linq;

    using Raven.Client.Indexes;

    using KnockKnock.Models;

    internal sealed class Knock_ByLocation : AbstractIndexCreationTask<Knock>
    {
        public Knock_ByLocation()
        {
            Map = knocks => knocks.Select(knock => new { _ = SpatialGenerate(nameof(Location), knock.Location.Latitude, knock.Location.Longitude) });
        }
    }
}