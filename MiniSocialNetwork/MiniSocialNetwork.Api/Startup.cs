using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Newtonsoft.Json.Serialization;
using Microsoft.Owin.Security.OAuth;
using MiniSocialNetwork.Api;
using MiniSocialNetwork.Api.Configs;
using MiniSocialNetwork.Api.Providers;

[assembly: OwinStartup(typeof(Startup))]

namespace MiniSocialNetwork.Api
{
    public class Startup
    {
        private IContainer container;

        public void Configuration(IAppBuilder app)
        {
            AutomapperConfig.Initialize();

            container = ConfigureDIContainer();

            var httpConfig = new HttpConfiguration();
            httpConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            ConfigureWebApi(httpConfig);
            app.UseAutofacWebApi(httpConfig);
            app.UseWebApi(httpConfig);

            ConfigureOAuth(app);
            
            app.UseCors(CorsOptions.AllowAll);
            
            app.MapSignalR();
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthAuthorizationServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider()
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