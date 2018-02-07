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

        public async Task<OperationDetails<CommentDTO>> CreateCommentAsync(CommentDTO comment)
        {
            Comment createdComment = Uow.CommentRepository.Create(Mapper.Map<CommentDTO, Comment>(comment));
            UserProfile commentAuthor = await Uow.ProfileManager.GetUserByIdAsync(createdComment.AuthorId);

            CommentDTO createdCommentDto = Mapper.Map<Comment, CommentDTO>(createdComment);
            createdCommentDto.AuthorName = GetAuthorName(commentAuthor);

            await Uow.SaveAsync();

            return new OperationDetails<CommentDTO>(
                true,
                "Comment created successfully.",
                "",
                createdCommentDto);
        }

        public async Task<OperationDetails> RemoveCommentAsync(String commentId)
        {
            try
            {
                await Uow.CommentRepository.DeleteAsync(commentId);
            }
            catch (CommentNotFoundException e)
            {
                return new OperationDetails(false, e.Message, "");
            }

            await Uow.SaveAsync();

            return new OperationDetails(true, "Comment deleted successfully.", "");
        }

        public async Task<IEnumerable<CommentDTO>> GetPostCommentsAsync(String postId)
        {
            IEnumerable<Comment> comments = await Uow.CommentRepository.GetPostComments(postId).ToListAsync();
            return Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(comments);
        }

        private String GetAuthorName(UserProfile user)
        {
            return $"{user.Firstname} {user.Lastname}";
        }
    }
}
