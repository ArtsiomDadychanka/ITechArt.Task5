using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MiniSocialNetwork.Dal.Entities;

namespace MiniSocialNetwork.Dal.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        static ApplicationContext()
        {
            //System.Data.Entity.Database.SetInitializer(new ContextInitializer());
        }

        public ApplicationContext()
        {
            
        }

        public ApplicationContext(string connectionString) : base(connectionString)
        {
        }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Post> UserPosts { get; set; }
    }
}
