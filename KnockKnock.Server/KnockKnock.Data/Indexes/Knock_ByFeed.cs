namespace KnockKnock.Data.Indexes
{
    using System.Linq;

    using Raven.Client.Indexes;

    using KnockKnock.Models;

    internal sealed class Knock_ByFeed : AbstractIndexCreationTask<Knock>
    {
        public Knock_ByFeed()
        {
            Map = knocks => knocks.Select(knock => new { FeedId = knock.FeedId } );
        }
    }
}