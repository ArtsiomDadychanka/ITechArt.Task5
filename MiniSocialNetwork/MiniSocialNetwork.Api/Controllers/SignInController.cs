using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MiniSocialNetwork.Api.Models;

namespace MiniSocialNetwork.Api.Controllers
{
    [RoutePrefix("api/auth")]
    [EnableCors("*", "*","*")]
    public class SignInController : ApiController
    {
        //login service
        [Route("")]
        public IHttpActionResult Post([FromBody] LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Credentials is not valid"),
                    ReasonPhrase = "Invalid credentials"
                };
                throw new HttpResponseException(response);
            }
            // init some action to bll
            return Ok();
        }
    }
}
