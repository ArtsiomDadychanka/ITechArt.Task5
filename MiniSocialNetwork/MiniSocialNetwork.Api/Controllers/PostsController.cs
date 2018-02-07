using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using MiniSocialNetwork.Api.Models;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Infrastructure;
using MiniSocialNetwork.Bll.Interfaces;

namespace MiniSocialNetwork.Api.Controllers
{
    [RoutePrefix("api/posts")]
    //[Authorize]
    public class PostsController : ApiController
    {
        private readonly IPostService postService;

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

            OperationDetails<PostDTO> result = await postService.CreatePostAsync(Mapper.Map<CreatedPostViewModel, PostDTO>(post));
            DisplayedPostViewModel createdPost = Mapper.Map<PostDTO, DisplayedPostViewModel>(result.Data);

            PostCommentsViewModel createdPostComments = new PostCommentsViewModel()
            {
                Post = createdPost,
                Comments = new List<DisplayedCommentViewModel>()
            };

            if (!result.Succedeed)
            {
                return BadRequest(result.Message);
            }

            return Created("", createdPostComments);
        }

        [Route("{id:Guid}")]
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
            List<PostCommentsViewModel> postComments = new List<PostCommentsViewModel>();
            foreach (PostDTO postDto in posts)
            {
                    postComments.Add(new PostCommentsViewModel()
                    {
                        Post = Mapper.Map<PostDTO, DisplayedPostViewModel>(postDto),
                        Comments = Mapper.Map<IEnumerable<CommentDTO>, IEnumerable<DisplayedCommentViewModel>>(postDto.Comments)
                    });
            }

            return Ok(postComments);
        }

        [Route("{postId:Guid}/like")]
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

        [Route("{postId:Guid}/unlike")]
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
