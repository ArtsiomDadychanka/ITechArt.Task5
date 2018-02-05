using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Dal.EF;
using MiniSocialNetwork.Dal.Entities;
using MiniSocialNetwork.Dal.Interfaces;

namespace MiniSocialNetwork.Dal.Repositories
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserProfile> GetUserByIdAsync(String id)
        {
            var user = await Database.UserProfiles.FindAsync(id);
            
            return user;
        }

        public IQueryable<UserProfile> GetUsersAsync()
        {
            return Database.UserProfiles.AsNoTracking();
        }
    }
}
