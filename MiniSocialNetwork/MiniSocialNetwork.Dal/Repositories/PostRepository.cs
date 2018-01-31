using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Dal.EF;
using MiniSocialNetwork.Dal.Entities;
using MiniSocialNetwork.Dal.Exceptions;
using MiniSocialNetwork.Dal.Interfaces;

namespace MiniSocialNetwork.Dal.Repositories
{
    public class PostRepository : IPostRepository
    {
        public ApplicationContext Database { get; set; }

        public PostRepository(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(Post post)
        {
            Database.UserPosts.Add(post);
        }

        public async void DeleteAsync(String id)
        {
            Post postToDelete = await Database.UserPosts.FindAsync(id);
            if (postToDelete == null)
            {
                throw new PostNotFoundException();
            }
            Database.UserPosts.Remove(postToDelete);
        }

        public IQueryable<Post> GetAll()
        {
            return Database.UserPosts.AsNoTracking();
        }
    }
}
