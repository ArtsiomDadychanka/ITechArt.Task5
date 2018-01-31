using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MiniSocialNetwork.Api.Models;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Interfaces;

namespace MiniSocialNetwork.Api.Controllers
{
    [RoutePrefix("api/posts")]
    //[Authorize]
    public class PostsController : ApiController
    {
        private IAuthenticationManager AuthenticationManager => Request.GetOwinContext().Authentication;
        private IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }
        
        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody] PostViewModel post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await postService.CreatePostAsync(Mapper.Map<PostViewModel, PostDTO>(post));

            if (!result.Succedeed)
            {
                return BadRequest(result.Message);
            }

            return Created("", post);
        }

        [Route("")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }

            var result = await postService.RemovePostAsync(id);

            if (!result.Succedeed)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }

        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            //return Ok(postService.GetPosts());
            //return Ok(new
            //{
            //    Name = AuthenticationManager.User.Identity.Name,
            //    Id = AuthenticationManager.User.Identity.GetUserId(),
            //    Auth = AuthenticationManager.User.Identity.IsAuthenticated
            //});
            return Ok(new
            {
                Name = User.Identity.Name,
                Auth = User.Identity.IsAuthenticated,
                Id = User.Identity.GetUserId()
            });
        }
    }
}
