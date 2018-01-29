using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using MiniSocialNetwork.Dal.Entities;

namespace MiniSocialNetwork.Dal.EF
{
    public class ContextInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            ApplicationUser user1 = new ApplicationUser()
            {
                Id = "test",
                UserName = @"test@gmail.com",
                Email = @"test@gmail.com",
                PhoneNumber = "3344565",
                Roles =
                {
                    new IdentityUserRole()
                    {
                        RoleId = "1",
                        UserId = "test",

                    }
                }
            };
            UserProfile pr1 = new UserProfile()
            {
                Id = "test",
                Firstname = "test"
            };
            ApplicationUser user2 = new ApplicationUser()
            {
                Id = "test2",
                UserName = @"test2@gmail.com",
                Email = @"test2@gmail.com",
                PhoneNumber = "33445625",
                Roles =
                {
                    new IdentityUserRole()
                    {
                        RoleId = "2",
                        UserId = "test2",

                    }
                }
            };
            UserProfile pr2 = new UserProfile()
            {
                Id = "test2",
                Firstname = "test2"
            };
            UserRole userRole = new UserRole()
            {
                Id = "1",
                Name = "User",
                Users =
                {
                    new IdentityUserRole()
                    {
                        RoleId = "1",
                        UserId = "test"
                    }
                }
            };
            UserRole userRole2 = new UserRole()
            {
                Id = "2",
                Name = "Admin",
                Users =
                {
                    new IdentityUserRole()
                    {
                        RoleId = "2",
                        UserId = "test2"
                    }
                }
            };
        }
    }
}
