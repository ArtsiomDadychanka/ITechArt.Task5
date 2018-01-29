using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Infrastructure;

namespace MiniSocialNetwork.Bll.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateAsync(UserDTO user);
        Task<ClaimsIdentity> AuthenticateAsync(UserDTO user);
    }
}
