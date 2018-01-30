using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using MiniSocialNetwork.Dal.EF;
using MiniSocialNetwork.Dal.Entities;
using MiniSocialNetwork.Dal.Identity;
using MiniSocialNetwork.Dal.Interfaces;

namespace MiniSocialNetwork.Dal.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext db;

        private readonly ApplicationUserManager userManager;
        private readonly ApplicationRoleManager roleManager;
        private readonly IUserProfileManager profileManager;

        public UnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<UserRole>(db));
            profileManager = new ProfileManagerRepository(db);
        }

        public ApplicationUserManager UserManager => userManager;
        public ApplicationRoleManager RoleManager => roleManager;
        public IUserProfileManager ProfileManager => profileManager;

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
                    userManager.Dispose();
                    roleManager.Dispose();
                    profileManager.Dispose();
                }
                this.disposed = true;
            }
        }
        #endregion
    }
}
