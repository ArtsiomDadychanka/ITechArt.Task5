using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using AutoMapper;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Infrastructure;
using MiniSocialNetwork.Bll.Interfaces;
using MiniSocialNetwork.Dal.Entities;
using MiniSocialNetwork.Dal.Interfaces;
using MiniSocialNetwork.Dal.Repositories;

namespace MiniSocialNetwork.Bll.Services
{
    public class UserService : Service, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<OperationDetails> CreateAsync(UserDTO user)
        {
            ApplicationUser appUser = await Uow.UserManager.FindByEmailAsync(user.Email);
            if (appUser == null)
            {
                appUser = Mapper.Map<UserDTO, ApplicationUser>(user);
                var result = await Uow.UserManager.CreateAsync(appUser);
                if (result.Errors.Any())
                {
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                }
                await Uow.UserManager.AddToRoleAsync(appUser.Id, user.Role);
                
                UserProfile userProfile = Mapper.Map<UserDTO, UserProfile>(user);
                Uow.ProfileManager.Create(userProfile);

                await Uow.SaveAsync();

                return new OperationDetails(true, "Registration successfully completed!", "");
            }
            return new OperationDetails(false, "A user with this login already exists!", "Email");
        }

        public async Task<ClaimsIdentity> AuthenticateAsync(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            
            ApplicationUser user = await Uow.UserManager.FindAsync(userDto.Email, userDto.Password);
            
            if (user != null)
                claim = await Uow.UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public void Dispose()
        {
            Uow.Dispose();
        }
    }
}
