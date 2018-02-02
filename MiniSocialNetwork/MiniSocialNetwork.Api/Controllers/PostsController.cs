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
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                return BadRequest("Invalid post id");
            }

            var result = await postService.RemovePostAsync(id.ToString());

            if (!result.Succedeed)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        /// <summary>
        /// Get users post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:Guid}")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                return BadRequest("Invalid user id");
            }

            var posts = await postService.GetUsersPostsAsync(id.ToString());
            IEnumerable<DisplayedPostViewModel> displayedPosts =
                Mapper.Map<IEnumerable<PostDTO>, IEnumerable<DisplayedPostViewModel>>(posts);

            return Ok(displayedPosts);
        }

        [Route("{id:Guid}/like")]
        [HttpPut]
        public async Task<IHttpActionResult> Like(Guid postId)
        {
            if (postId.Equals(Guid.Empty))
            {
                return BadRequest("Invalid post id");
            }

            var result = await postService.Like(postId.ToString());
            if (!result.Succedeed)
            {
                return InternalServerError();
            }
            return Ok(result.Message);
        }

        [Route("{id:Guid}/unlike")]
        [HttpPut]
        public async Task<IHttpActionResult> Unlike(Guid postId)
        {
            if (postId.Equals(Guid.Empty))
            {
                return BadRequest("Invalid post id");
            }

            var result = await postService.Unlike(postId.ToString());
            if (!result.Succedeed)
            {
                return InternalServerError();
            }
            return Ok(result.Message);
        }
    }
}
