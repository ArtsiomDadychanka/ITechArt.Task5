using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Dal.Entities;

namespace MiniSocialNetwork.Dal.Interfaces
{
    public interface IUserRepository: IDisposable
    {
        Task<UserProfile> GetUserByIdAsync(String id);
        IQueryable<UserProfile> GetUsersAsync();
    }
}
