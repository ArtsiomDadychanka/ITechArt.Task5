using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using MiniSocialNetwork.Dal.Entities;

namespace MiniSocialNetwork.Dal.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Post> UserPosts { get; set; }

        static ApplicationContext()
        {
            //System.Data.Entity.Database.SetInitializer(new ContextInitializer());
        }

        public ApplicationContext(string connectionString) : base(connectionString)
        {
        }
    }
}
