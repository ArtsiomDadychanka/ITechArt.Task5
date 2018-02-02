using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MiniSocialNetwork.Dal.EF;
using MiniSocialNetwork.Dal.Entities;
using MiniSocialNetwork.Dal.Identity;
using MiniSocialNetwork.Dal.Interfaces;

namespace MiniSocialNetwork.Dal.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext db;

        public UnitOfWork(ApplicationContext context)
        {
            db = context;
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            RoleManager = new ApplicationRoleManager(new RoleStore<UserRole>(db));
            ProfileManager = new ProfileManagerRepository(db);
            PostRepository = new PostRepository(db);
            CommentRepository = new CommentRepository(db);
        }

        public ApplicationUserManager UserManager { get; }
        public ApplicationRoleManager RoleManager { get; }
        public IUserProfileManager ProfileManager { get; }
        public IPostRepository PostRepository { get; }
        public ICommentRepository CommentRepository { get; set; }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                    ProfileManager.Dispose();
                    PostRepository.Dispose();
                    CommentRepository.Dispose();
                }
                this.disposed = true;
            }
        }
        #endregion
    }
}
