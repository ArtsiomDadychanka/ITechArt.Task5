using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MiniSocialNetwork.Api.Models;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Infrastructure;
using MiniSocialNetwork.Bll.Interfaces;
using MiniSocialNetwork.Bll.Services;
using MiniSocialNetwork.Dal.Identity;

namespace MiniSocialNetwork.Api.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private IAuthenticationManager AuthenticationManager => Request.GetOwinContext().Authentication;
        private ApplicationUserManager userManager;
        public ApplicationUserManager UserManager
        {
            get => userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => userManager = value;
        }

        public IUserService UserService { get; }

        //public AccountController(ApplicationUserManager userManager)
        //{
        //    UserManager = userManager;
            
        //}

        public AccountController(IUserService userService)
        {
            UserService = userService;
        }

        //public AccountController(ApplicationUserManager userManager, IUserService userService) : this(userManager)
        //{
        //    UserService = userService;
        //}

        // TODO
        [Route("signin")]
        public async Task<IHttpActionResult> Post([FromBody] LoginViewModel loginViewModel)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserDTO userToSignIn = Mapper.Map<LoginViewModel, UserDTO>(loginViewModel);
            ClaimsIdentity claim = await UserService.AuthenticateAsync(userToSignIn);
            if (claim == null)
            {
                var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Could bot authenticate."),
                    ReasonPhrase = "Could bot authenticate."
                };
                throw new HttpResponseException(errorResponse);
            } 
            AuthenticationManager.SignOut();
            //FormsAuthentication.SetAuthCookie(loginViewModel.Email, true);
            //SetPrincipal(new GenericPrincipal(new GenericIdentity(loginViewModel.Email), null));
            AuthenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = true
            }, claim);

            return Ok(new
            {
                Name = User.Identity.Name,
                Auth = User.Identity.IsAuthenticated,
                Id = User.Identity.GetUserId()
            });
            //return Ok(new
            //{
            //    Name = HttpContext.Current.User.Identity.Name,
            //    Id = HttpContext.Current.User.Identity.GetUserId()
            //});
        }

        [Route("signup")]
        public async Task<IHttpActionResult> Post([FromBody] RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserDTO user = Mapper.Map<RegisterViewModel, UserDTO>(registerViewModel);
            OperationDetails operationDetails = await UserService.CreateAsync(user);

            if (!operationDetails.Succedeed)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(operationDetails.Message),
                    ReasonPhrase = operationDetails.Message
                };
                throw new HttpResponseException(response);
            }

            return Ok();
        }
        // TODO: temporary for role creating
        [Route("createrole")]
        public async Task<IHttpActionResult> Post()
        {
            OperationDetails operationDetails = await UserService.CreateRoleAsync();

            if (!operationDetails.Succedeed)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(operationDetails.Message),
                    ReasonPhrase = operationDetails.Message
                };
                throw new HttpResponseException(response);
            }
            return Ok();
        }

        private void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
    }
}
