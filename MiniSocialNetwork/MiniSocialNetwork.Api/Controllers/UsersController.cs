using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MiniSocialNetwork.Api.Controllers
{
    [RoutePrefix("api/users")]
    //[Authorize]
    public class UsersController : ApiController
    {
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok();
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Get(string id)
        {
            return Ok();
        }
    }
}
