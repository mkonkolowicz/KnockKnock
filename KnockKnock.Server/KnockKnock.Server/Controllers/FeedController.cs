using System.Threading.Tasks;

namespace KnockKnock.Server.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using KnockKnock.Data;
    using KnockKnock.Data.Models;
    using KnockKnock.Models;

    public class FeedController : ApiController
    {
        private static readonly IDataRepository Repository = DataRepository.Singleton;

        // GET: api/Feed
        public async Task<IHttpActionResult> GetAsync([FromUri] double longitude, [FromUri] double latitude, [FromUri] double radius)
        {
            var criteria = new FeedCriteria()
            {
                Location = new Location() {Latitude = latitude, Longitude = longitude},
                Radius = radius
            };

            var feeds = (await Repository.GetFeedsAsync(criteria)).ToArray();

            if (!feeds.Any())
            {
                return Ok();
            }

            return Ok(feeds);
        }

        public async Task<IHttpActionResult> PostAsync([FromBody] Feed feed)
        {
            if (feed == null)
            {
                return BadRequest();
            }
            try
            {
                var id = await Repository.SaveFeedAsync(feed);
                return Ok(id);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}