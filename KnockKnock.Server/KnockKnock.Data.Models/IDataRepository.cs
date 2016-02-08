using KnockKnock.Models;

namespace KnockKnock.Data.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    

    public interface IDataRepository
    {
        Task<IEnumerable<Feed>> GetFeedsAsync(FeedCriteria criteria);

        Task<string> SaveFeedAsync(Feed feed);

        Task<IEnumerable<Knock>> GetKnocksAsync(KnockCriteria criteria);

        Task<string> SaveKnockAsync(Knock knock);
    }
}