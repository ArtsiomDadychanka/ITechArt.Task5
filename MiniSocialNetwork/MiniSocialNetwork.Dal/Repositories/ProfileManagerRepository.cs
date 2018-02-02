using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Dal.EF;
using MiniSocialNetwork.Dal.Entities;
using MiniSocialNetwork.Dal.Interfaces;

namespace MiniSocialNetwork.Dal.Repositories
{
    public class ProfileManagerRepository : Repository, IUserProfileManager
    {
        public ProfileManagerRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }



        public void Create(UserProfile user)
        {
            Database.UserProfiles.Add(user);
            Database.SaveChanges();
        }
    }
}
