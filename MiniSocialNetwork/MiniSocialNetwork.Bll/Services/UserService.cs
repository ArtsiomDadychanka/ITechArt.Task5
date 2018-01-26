using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Interfaces;
using MiniSocialNetwork.Dal.Interfaces;

namespace MiniSocialNetwork.Bll.Services
{
    class UserService : Service, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Create(UserDTO user)
        {
            Uow.ProfileManager.Create();
        }
    }
}
