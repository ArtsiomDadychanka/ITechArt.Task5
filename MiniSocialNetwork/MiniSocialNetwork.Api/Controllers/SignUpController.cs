using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MiniSocialNetwork.Api.Models;

namespace MiniSocialNetwork.Api.Controllers
{
    [RoutePrefix("api/signup")]
    [EnableCors("*", "*", "*")]
    public class SignUpController : ApiController
    {
        
        [Route("")]
        public IHttpActionResult Post([FromBody] RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Input data is not valid"),
                    ReasonPhrase = "Invalid input data"
                };
                throw new HttpResponseException(response);
            }
            // init some action to bll
            return Ok();
        }
    }
}
