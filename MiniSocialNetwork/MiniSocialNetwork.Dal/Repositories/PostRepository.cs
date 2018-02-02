using System;
using System.Data.Entity;
using System.Linq;
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

        public IQueryable<Post> GetUsersPosts(String id)
        {
            return Database.UserPosts.Where(p => p.AuthorId == id).AsNoTracking();
        }

        public async void Like(String postId)
        {
            Post likedPost = await Database.UserPosts.FindAsync(postId);
            if (likedPost == null)
            {
                throw new PostNotFoundException();
            }

            likedPost.Likes += 1;
        }
        public async void Unlike(String postId)
        {
            Post unlikedPost = await Database.UserPosts.FindAsync(postId);
            if (unlikedPost == null)
            {
                throw new PostNotFoundException();
            }

            if (unlikedPost.Likes > 0)
            {
                unlikedPost.Likes -= 1;
            }
        }
    }
}
