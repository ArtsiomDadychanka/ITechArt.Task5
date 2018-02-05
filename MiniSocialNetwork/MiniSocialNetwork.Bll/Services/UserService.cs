using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Interfaces;
using MiniSocialNetwork.Dal.Entities;
using MiniSocialNetwork.Dal.Interfaces;

namespace MiniSocialNetwork.Bll.Services
{
    public class UserService : Service, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<UserDTO> GetUserAsync(String id)
        {
            UserProfile user = await Uow.UserRepository.GetUserByIdAsync(id);

            return Mapper.Map<UserProfile, UserDTO>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            IEnumerable<UserProfile> users = await Uow.UserRepository.GetUsersAsync().ToArrayAsync();

            return Mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserDTO>>(users);
        }
    }
}
