using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using MiniSocialNetwork.Dal.Entities;
using MiniSocialNetwork.Dal.Interfaces;

namespace MiniSocialNetwork.Dal.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Post> UserPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        static ApplicationContext()
        {
            //System.Data.Entity.Database.SetInitializer(new ContextInitializer());
        }
        // TODO: remove explicit connection string
        // i did it for migrations
        public ApplicationContext() : base("Server=.;initial catalog=SocialNetwork;Integrated Security=true;")
        {
            
        }

        public ApplicationContext(string connectionString) : base(connectionString)
        {
        }
    }
}
