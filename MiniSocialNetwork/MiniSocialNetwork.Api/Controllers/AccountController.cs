﻿using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Microsoft.Owin.Security;
using MiniSocialNetwork.Api.Models;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Infrastructure;
using MiniSocialNetwork.Bll.Interfaces;

namespace MiniSocialNetwork.Api.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        public IAuthService UserService { get; }

        public AccountController(IAuthService userService)
        {
            UserService = userService;
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
