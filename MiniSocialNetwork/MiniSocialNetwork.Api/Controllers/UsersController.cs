using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using MiniSocialNetwork.Api.Models;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Interfaces;

namespace MiniSocialNetwork.Api.Controllers
{
    [RoutePrefix("api/users")]
    //[Authorize]
    public class UsersController : ApiController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("{id:Guid}")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                return BadRequest();
            }

            UserDTO user = await userService.GetUserAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }
            var displayedUser = Mapper.Map<UserDTO, DisplayedUserViewModel>(user);

            return Ok(displayedUser);
        }

        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var users = await userService.GetUsersAsync();

            return Ok(users);
        }
    }
}
