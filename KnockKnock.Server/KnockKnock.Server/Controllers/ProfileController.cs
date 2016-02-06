using KnockKnock.Data.Models;

namespace KnockKnock.Server.Controllers
{
    using System.Web.Http;
    using KnockKnock.Models;
    using Data;
    public class ProfileController: ApiController
    {
        //private static readonly IDataRepository Repository = DataRepository.Singleton;
        //// GET: api/Feed
        //public IHttpActionResult Get([FromUri] Person personCriteria)
        //{
        //    if (personCriteria == null)
        //    {
        //        return BadRequest("Bad Request: person is null");
        //    }

        //    var personResult = Repository.GetPerson(personCriteria);

        //    return Ok(personResult);
        //}
        
        //// POST: api/Feed
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Feed/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Feed/5
        //public void Delete(int id)
        //{
        //}
    }
}