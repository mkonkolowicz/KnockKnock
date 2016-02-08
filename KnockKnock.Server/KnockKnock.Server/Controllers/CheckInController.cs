using KnockKnock.Data.Models;

namespace KnockKnock.Server.Controllers
{
    using System.Web.Http;
    using Data;
    public class CheckInController : ApiController
    {
        private static readonly IDataRepository Repository = DataRepository.Singleton;

        // GET: api/Feed
        //public IHttpActionResult Post([FromUri] Location location)
        //{
            
        //}
    }
}
