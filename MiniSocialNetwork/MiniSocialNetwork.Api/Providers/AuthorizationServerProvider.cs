using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using AutoMapper;
using Microsoft.Owin.Security;
using MiniSocialNetwork.Api.Models;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Interfaces;

namespace MiniSocialNetwork.Api.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IAuthService userService;

        public AuthorizationServerProvider(IAuthService userService)
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

            String userId = result.Claims.First(c => c.Type == "id").Value;

            AuthenticationTicket ticket = new AuthenticationTicket(
                result, 
                CreateProperties(userId));
            context.Validated(ticket);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string,
                string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        private AuthenticationProperties CreateProperties(String id)
        {
            IDictionary<string, string>
                data = new Dictionary<string, string>
                {
                    { "id", id }
                };
            return new AuthenticationProperties(data);
        }
    }
}