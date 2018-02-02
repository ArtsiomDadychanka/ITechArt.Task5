using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Infrastructure;
using MiniSocialNetwork.Dal.Identity;

namespace MiniSocialNetwork.Bll.Interfaces
{
    public interface IAuthService : IDisposable
    {
        // TODO: temporary for role creating
        Task<OperationDetails> CreateRoleAsync();

        Task<OperationDetails> CreateAsync(UserDTO user);
        Task<ClaimsIdentity> AuthenticateAsync(UserDTO user);
    }
}
