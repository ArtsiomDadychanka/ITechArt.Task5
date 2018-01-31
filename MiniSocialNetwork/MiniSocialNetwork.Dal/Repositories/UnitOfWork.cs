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

        public UnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            RoleManager = new ApplicationRoleManager(new RoleStore<UserRole>(db));
            ProfileManager = new ProfileManagerRepository(db);
            PostRepository = new PostRepository(db);
        }

        //public static UnitOfWork CreateManager(IdentityFactoryOptions<ApplicationUserManager> options,
        //    IOwinContext context)
        //{
        //    //return new UnitOfWork();
        //    ApplicationUserManager.Create(options, context);
        //}

        public ApplicationUserManager UserManager { get; }
        public ApplicationRoleManager RoleManager { get; }
        public IUserProfileManager ProfileManager { get; }
        public IPostRepository PostRepository { get; }

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
                }
                this.disposed = true;
            }
        }
        #endregion
    }
}
