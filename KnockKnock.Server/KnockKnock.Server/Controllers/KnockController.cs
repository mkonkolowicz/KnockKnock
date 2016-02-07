using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KnockKnock.Server.Controllers
{
    using System.Web.Http;

    using KnockKnock.Data;
    using KnockKnock.Data.Models;
    using KnockKnock.Models;
    
    public class KnockController : ApiController
    {
        private static readonly IDataRepository Repository = DataRepository.Singleton;

        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetAsync([FromUri] double longitude, [FromUri] double latitude, [FromUri] double radius)
        {
            var criteria = new KnockCriteria()
            {
                Location = new Location()
                {
                    Latitude = latitude,
                    Longitude = longitude
                },
                Radius = radius
            };
            var knocks = (await Repository.GetKnocksAsync(criteria)).ToArray();

            if (!knocks.Any())
            {
                return Ok();
            }
            return Ok(knocks);
        }

        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetAsync([FromUri] string feedId)
        {
            var criteria = new KnockCriteria()
            {
                FeedId = feedId
            };
            var knocks = (await Repository.GetKnocksAsync(criteria)).ToArray();

            if (!knocks.Any())
            {
                return Ok();
            }

            return Ok(knocks);
        }

        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> PostAsync([FromBody] Knock knock)
        {
            if (knock == null)
            {
                return Ok();
            }
            try
            {
                var id = await Repository.SaveKnockAsync(knock);
                return Ok(id);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

    }
}
