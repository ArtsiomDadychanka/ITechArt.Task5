using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Dal.EF;
using MiniSocialNetwork.Dal.Entities;
using MiniSocialNetwork.Dal.Exceptions;
using MiniSocialNetwork.Dal.Interfaces;

namespace MiniSocialNetwork.Dal.Repositories
{
    public class CommentRepository : Repository, ICommentRepository
    {
        public CommentRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public void Create(Comment post)
        {
            Database.Comments.Add(post);
        }

        public async void DeleteAsync(String id)
        {
            Comment commentToDelete = await Database.Comments.FindAsync(id);
            if (commentToDelete == null)
            {
                throw new CommentNotFoundException();
            }
            Database.Comments.Remove(commentToDelete);
        }

        public IQueryable<Comment> GetPostComments(String postId)
        {
            return Database.Comments.Where(c => c.PostId == postId).AsNoTracking();
        }
    }
}
