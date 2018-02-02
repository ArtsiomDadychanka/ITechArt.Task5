using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Infrastructure;

namespace MiniSocialNetwork.Bll.Interfaces
{
    public interface ICommentService
    {
        Task<OperationDetails> CreateCommentAsync(CommentDTO comment);
        Task<OperationDetails> RemoveCommentAsync(String commentId);
        Task<IEnumerable<CommentDTO>> GetPostCommentsAsync(String postId);
    }
}
