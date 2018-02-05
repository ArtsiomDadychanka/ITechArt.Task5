using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Bll.DTO;

namespace MiniSocialNetwork.Bll.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserAsync(String id);
        Task<IEnumerable<UserDTO>> GetUsersAsync();
    }
}
