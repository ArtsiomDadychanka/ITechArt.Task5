using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
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
        public async Task<IHttpActionResult> Post([FromBody] CreatedPostViewModel post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await postService.CreatePostAsync(Mapper.Map<CreatedPostViewModel, PostDTO>(post));

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
            var posts = postService.GetUsersPosts(id.ToString());
            IEnumerable<DisplayedPostViewModel> displayedPosts =
                Mapper.Map<IEnumerable<PostDTO>, IEnumerable<DisplayedPostViewModel>>(posts);

            return Ok(displayedPosts);
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
