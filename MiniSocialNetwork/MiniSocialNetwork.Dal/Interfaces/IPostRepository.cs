using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Dal.Entities;

namespace MiniSocialNetwork.Dal.Interfaces
{
    public interface IPostRepository : IDisposable
    {
        Post Create(Post post);
        void DeleteAsync(String id);
        IQueryable<Post> GetAll();
        IQueryable<Post> GetUsersPosts(String id);
        void Like(String postId);
        void Unlike(String postId);
    }
}
