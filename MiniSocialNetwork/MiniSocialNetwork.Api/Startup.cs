using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Newtonsoft.Json.Serialization;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using MiniSocialNetwork.Api;
using MiniSocialNetwork.Api.Configs;
using MiniSocialNetwork.Api.Providers;
using MiniSocialNetwork.Bll.Interfaces;
using MiniSocialNetwork.Bll.Services;
using MiniSocialNetwork.Dal.EF;
using MiniSocialNetwork.Dal.Identity;

[assembly: OwinStartup(typeof(Startup))]

namespace MiniSocialNetwork.Api
{
    public class Startup
    {
        private IContainer container;
        public AuthorizationServerProvider AuthorizationServerProvider { get; set; }

        public void Configuration(IAppBuilder app)
        {
            AutomapperConfig.Initialize();

            container = ConfigureDIContainer();
            using (var scope = container.BeginLifetimeScope())
            {
                AuthorizationServerProvider = container.Resolve<AuthorizationServerProvider>();
            }

            var httpConfig = new HttpConfiguration();
            ConfigureOAuth(app);
            ConfigureWebApi(httpConfig);
            app.UseCors(CorsOptions.AllowAll);

            httpConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //app.MapSignalR();
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(httpConfig);
            app.UseWebApi(httpConfig);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthAuthorizationServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = AuthorizationServerProvider
            };

            app.UseOAuthAuthorizationServer(oAuthAuthorizationServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private IContainer ConfigureDIContainer()
        {
            var builder = new ContainerBuilder();
            AutofacConfig.Register(builder);
            return builder.Build();
        }
    }
}