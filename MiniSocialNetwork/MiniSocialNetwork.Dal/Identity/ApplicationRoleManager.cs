using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MiniSocialNetwork.Dal.Entities;

namespace MiniSocialNetwork.Dal.Identity
{
    public class ApplicationRoleManager : RoleManager<UserRole>
    {
        public ApplicationRoleManager(IRoleStore<UserRole, string> store) : base(store)
        {
        }
    }
}
