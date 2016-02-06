namespace KnockKnock.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Raven.Client;
    using Raven.Client.Embedded;
    using Raven.Client.Indexes;

    using KnockKnock.Data.Indexes;
    using KnockKnock.Data.Models;
    using KnockKnock.Models;

    public sealed class DataRepository : IDataRepository
    {
        private static readonly IDataRepository Instance = new DataRepository();

        private DataRepository()
        {
            using (var store = GetInitializedStore())
            {
                IndexCreation.CreateIndexes(typeof(Feed_ByLocationAndName).Assembly, store);
                IndexCreation.CreateIndexes(typeof(Knock_ByFeed).Assembly, store);
                IndexCreation.CreateIndexes(typeof(Knock_ByLocation).Assembly, store);
            }
        }

        public static IDataRepository Singleton { get; } = Instance;

        private static EmbeddableDocumentStore GetInitializedStore()
        {
            var store = new EmbeddableDocumentStore() { UseEmbeddedHttpServer = false, DataDirectory = "RavenDB" };

            store.Initialize();

            return store;
        }

        #region Feeds

        public async Task<IEnumerable<Feed>> GetFeedsAsync(FeedCriteria criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException(nameof(criteria));

            using (var store = GetInitializedStore())
            using (var session = store.OpenAsyncSession())
            {
                var query = session.Query<Feed, Feed_ByLocationAndName>()
                                   .Spatial(x => x.Location, spatial => spatial.WithinRadius(criteria.Radius, criteria.Location.Latitude, criteria.Location.Longitude));

                if (!String.IsNullOrWhiteSpace(criteria.FeedId))
                {
                    return await query.Where(x => String.Equals(x.Id, criteria.FeedId, StringComparison.OrdinalIgnoreCase)).ToListAsync();
                }

                if (!String.IsNullOrWhiteSpace(criteria.FeedName))
                {
                    return await query.Where(x => x.Name.Contains(criteria.FeedName)).ToListAsync();
                }

                return await query.ToListAsync();
            }
        }

        public async Task<string> SaveFeedAsync(Feed feed)
        {
            if (feed == null)
                throw new ArgumentNullException(nameof(feed));

            using (var store = GetInitializedStore())
            using (var session = store.OpenAsyncSession())
            {
                await session.StoreAsync(feed);
                await session.SaveChangesAsync();
                return feed.Id;
            }
        }

        #endregion //Feeds

        #region Knocks

        private async Task<IEnumerable<Knock>> GetKnocksByFeedId(IAsyncDocumentSession session, string feedId)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            if (String.IsNullOrWhiteSpace(feedId))
                throw new ArgumentNullException(nameof(feedId));

            return await session.Query<Knock, Knock_ByFeed>().Where(knock => knock.FeedId==feedId).ToListAsync();
        }

        private async Task<IEnumerable<Knock>> GetKnocksByLocation(IAsyncDocumentSession session, Location location, double radius)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            if (location == null)
                throw new ArgumentNullException(nameof(location));

            return await session.Query<Knock, Knock_ByLocation>()
                                .Spatial(x => x.Location, spatial => spatial.WithinRadius(radius, location.Latitude, location.Longitude))
                                .ToListAsync();
        }

        public async Task<IEnumerable<Knock>> GetKnocksAsync(KnockCriteria criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException(nameof(criteria));

            using (var store = GetInitializedStore())
            using (var session = store.OpenAsyncSession())
            {
                if (!String.IsNullOrWhiteSpace(criteria.FeedId))
                    return await GetKnocksByFeedId(session, criteria.FeedId);

                return await GetKnocksByLocation(session, criteria.Location, criteria.Radius);
            }
        }

        public async Task<string> SaveKnockAsync(Knock knock)
        {
            if (knock == null)
                throw new ArgumentNullException(nameof(knock));

            using (var store = GetInitializedStore())
            using (var session = store.OpenAsyncSession())
            {
                await session.StoreAsync(knock);
                await session.SaveChangesAsync();
                return knock.Id;
            }
        }

        #endregion //Knocks
    }
}
