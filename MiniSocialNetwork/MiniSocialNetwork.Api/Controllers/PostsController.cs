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

        /// <summary>
        /// Get users post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:Guid}")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            return Ok(postService.GetUsersPosts(id.ToString()));
        }

        [Route("{id:Guid}/like")]
        [HttpPut]
        public async Task<IHttpActionResult> Like(Guid postId)
        {
            var result = await postService.Like(postId.ToString());
            if (!result.Succedeed)
            {
                return InternalServerError();
            }
            return Ok();
        }

        [Route("{id:Guid}/unlike")]
        [HttpPut]
        public async Task<IHttpActionResult> Unlike(Guid postId)
        {
            var result = await postService.Unlike(postId.ToString());
            if (!result.Succedeed)
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
