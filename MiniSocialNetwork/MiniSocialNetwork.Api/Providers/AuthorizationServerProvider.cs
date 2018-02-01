using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using AutoMapper;
using MiniSocialNetwork.Api.Models;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Interfaces;

namespace MiniSocialNetwork.Api.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IUserService userService;

        public AuthorizationServerProvider(IUserService userService)
        {
            this.userService = userService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            Debug.WriteLine("qwe");
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            LoginViewModel login = new LoginViewModel() {Email = context.UserName, Password = context.Password};
            UserDTO userToAuth = Mapper.Map<LoginViewModel, UserDTO>(login);

            var result = await userService.AuthenticateAsync(userToAuth);
            if (result == null)
            {
                context.SetError("Invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);
        }
    }
}