namespace KnockKnock.Data.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KnockKnock.Models;

    public interface IDataRepository
    {
        Task<IEnumerable<Feed>> GetFeedsAsync(FeedCriteria criteria);

        Task<string> SaveFeedAsync(Feed feed);

        Task<IEnumerable<Knock>> GetKnocksAsync(KnockCriteria criteria);

        Task<string> SaveKnockAsync(Knock knock);
    }
}