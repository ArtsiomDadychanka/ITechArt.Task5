using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Infrastructure;
using MiniSocialNetwork.Bll.Interfaces;
using MiniSocialNetwork.Dal.Entities;
using MiniSocialNetwork.Dal.Exceptions;
using MiniSocialNetwork.Dal.Interfaces;

namespace MiniSocialNetwork.Bll.Services
{
    public class CommentService : Service, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<OperationDetails> CreateCommentAsync(CommentDTO comment)
        {
            Uow.CommentRepository.Create(Mapper.Map<CommentDTO, Comment>(comment));;
            await Uow.SaveAsync();

            return new OperationDetails(true, "Comment created successfully.", "");
        }

        public async Task<OperationDetails> RemoveCommentAsync(String commentId)
        {
            try
            {
                Uow.CommentRepository.DeleteAsync(commentId);
            }
            catch (CommentNotFoundException e)
            {
                return new OperationDetails(false, e.Message, "");
            }

            await Uow.SaveAsync();

            return new OperationDetails(true, "Post deleted successfully.", "");
        }

        public async Task<IEnumerable<CommentDTO>> GetPostCommentsAsync(String postId)
        {
            IEnumerable<Comment> comments = await Uow.CommentRepository.GetPostComments(postId).ToListAsync();
            return Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(comments);
        }
    }
}
