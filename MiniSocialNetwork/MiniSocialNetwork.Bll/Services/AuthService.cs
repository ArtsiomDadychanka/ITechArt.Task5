using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Infrastructure;
using MiniSocialNetwork.Bll.Interfaces;
using MiniSocialNetwork.Dal.Entities;
using MiniSocialNetwork.Dal.Identity;
using MiniSocialNetwork.Dal.Interfaces;
using MiniSocialNetwork.Dal.Repositories;

namespace MiniSocialNetwork.Bll.Services
{
    public class AuthService : Service, IAuthService
    {
        public AuthService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<OperationDetails> CreateAsync(UserDTO user)
        {
            ApplicationUser appUser = await Uow.UserManager.FindByEmailAsync(user.Email);
            if (appUser == null)
            {
                appUser = Mapper.Map<UserDTO, ApplicationUser>(user);

                try
                {
                    var result = await Uow.UserManager.CreateAsync(appUser, user.Password);
                    if (result.Errors.Any())
                    {
                        return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                    }
                    await Uow.UserManager.AddToRoleAsync(appUser.Id, user.Role);

                    CreateUserProfile(appUser.Id, user);

                    await Uow.SaveAsync();
                }
                catch (DbEntityValidationException e)
                {
                    return new OperationDetails(false, "Validation failed.", "");
                }

                return new OperationDetails(true, "Registration successfully completed!", "");
            }

            return new OperationDetails(false, "A user with this login already exists!", "Email");
        }

        // TODO: temporary for role creating
        public async Task<OperationDetails> CreateRoleAsync()
        {
            try
            {
                await Uow.RoleManager.CreateAsync(
                    new UserRole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "User"
                    });

                await Uow.RoleManager.CreateAsync(
                    new UserRole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Admin"
                    });

                await Uow.SaveAsync();
            }
            catch (Exception e)
            {
                return new OperationDetails(false, e.Message, "");
            }
            return new OperationDetails(true, "", "");
        }

        public async Task<ClaimsIdentity> AuthenticateAsync(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            
            ApplicationUser user = await Uow.UserManager.FindAsync(userDto.Email, userDto.Password);

            if (user != null)
            {
                claim = await Uow.UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ExternalBearer);
                claim.AddClaim(new Claim("id", user.Id));
            }
            
            return claim;
        }

        #region Helpers
        private void CreateUserProfile(string id, UserDTO user)
        {
            UserProfile userProfile = Mapper.Map<UserDTO, UserProfile>(user);
            userProfile.Id = id;

            Uow.ProfileManager.Create(userProfile);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            Uow.Dispose();
        }
        #endregion
    }
}
