using Microsoft.AspNet.Identity.EntityFramework;

namespace MiniSocialNetwork.Dal.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            
        }

        public virtual UserProfile ClientProfile { get; set; }
    }
}