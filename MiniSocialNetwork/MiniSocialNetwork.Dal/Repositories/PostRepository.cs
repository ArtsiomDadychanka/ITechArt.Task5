using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MiniSocialNetwork.Dal.EF;
using MiniSocialNetwork.Dal.Entities;
using MiniSocialNetwork.Dal.Exceptions;
using MiniSocialNetwork.Dal.Interfaces;

namespace MiniSocialNetwork.Dal.Repositories
{
    public class PostRepository : Repository, IPostRepository
    {
        public PostRepository(ApplicationContext db) : base(db)
        {
        }

        public Post Create(Post post)
        {
            return Database.UserPosts.Add(post);
        }

        public async Task DeleteAsync(String id)
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

        public IQueryable<Post> GetUsersPosts(String id)
        {
            return Database.UserPosts.Where(p => p.AuthorId == id).AsNoTracking();
        }

        public async Task Like(String postId)
        {
            Post likedPost = await Database.UserPosts.FindAsync(postId);
            if (likedPost == null)
            {
                throw new PostNotFoundException();
            }

            likedPost.Likes++;
            Database.Entry(likedPost).State = EntityState.Modified;
        }
        public async Task Unlike(String postId)
        {
            Post unlikedPost = await Database.UserPosts.FindAsync(postId);
            if (unlikedPost == null)
            {
                throw new PostNotFoundException();
            }

            if (unlikedPost.Likes > 0)
            {
                unlikedPost.Likes--;
                Database.Entry(unlikedPost).State = EntityState.Modified;
            }
        }
    }
}
