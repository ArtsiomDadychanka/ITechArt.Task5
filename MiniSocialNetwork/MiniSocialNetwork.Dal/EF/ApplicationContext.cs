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
        public DbSet<Dialog> Dialogs { get; set; }
        public DbSet<Message> Messages { get; set; }

        public ApplicationContext() : base("Name=SocialNetworkDbContext")
        {
        }
    }
}
