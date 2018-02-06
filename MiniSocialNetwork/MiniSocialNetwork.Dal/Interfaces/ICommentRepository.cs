using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Dal.Entities;

namespace MiniSocialNetwork.Dal.Interfaces
{
    public interface ICommentRepository : IDisposable
    {
        Comment Create(Comment post);
        void DeleteAsync(String id);
        IQueryable<Comment> GetPostComments(String postId);
    }
}
