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
        public DbSet<Comment> Type { get; set; }

        static ApplicationContext()
        {
            //System.Data.Entity.Database.SetInitializer(new ContextInitializer());
        }

        public ApplicationContext() : base("Server=.;initial catalog=SocialNetwork;Integrated Security=true;")
        {
            
        }

        public ApplicationContext(string connectionString) : base(connectionString)
        {
        }
    }
}
