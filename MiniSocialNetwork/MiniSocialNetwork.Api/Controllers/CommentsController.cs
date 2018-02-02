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
    [RoutePrefix("api/comments")]
    public class CommentsController : ApiController
    {
        private ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [Route("{postId:Guid}")]
        public async Task<IHttpActionResult> Get(Guid postId)
        {
            if (postId.Equals(Guid.Empty))
            {
                return BadRequest("Invalid post id");
            }

            var comments = await commentService.GetPostCommentsAsync(postId.ToString());
            IEnumerable<DisplayedCommentViewModel> displayedComments =
                Mapper.Map<IEnumerable<CommentDTO>, IEnumerable<DisplayedCommentViewModel>>(comments);

            return Ok(displayedComments);
        }

        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody]CreatedCommentViewModel commentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await commentService.CreateCommentAsync(Mapper.Map<CreatedCommentViewModel, CommentDTO>(commentViewModel));

            if (!result.Succedeed)
            {
                return BadRequest(result.Message);
            }

            return Created("", commentViewModel);
        }

        [Route("{id:Guid}")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                return BadRequest("Invalid comment id");
            }

            var result = await commentService.RemoveCommentAsync(id.ToString());

            if (!result.Succedeed)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
    }
}
