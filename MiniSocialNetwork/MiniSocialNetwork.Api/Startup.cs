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
using MiniSocialNetwork.Api;
using MiniSocialNetwork.Api.Configs;
using MiniSocialNetwork.Bll.Interfaces;
using MiniSocialNetwork.Bll.Services;
using MiniSocialNetwork.DIConfig;

[assembly: OwinStartup(typeof(Startup))]

namespace MiniSocialNetwork.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutomapperConfig.Initialize();

            var builder = new ContainerBuilder();

            var httpConfig = new HttpConfiguration();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            AutofacConfig.Register(builder);

            ConfigureOAuthTokenGeneration(app);
            ConfigureWebApi(httpConfig);
            app.UseCors(CorsOptions.AllowAll);

            var container = builder.Build();
            app.CreatePerOwinContext<IUserService>(CreateUserService(container));
            httpConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(httpConfig);
            app.UseWebApi(httpConfig);
        }

        // TODO
        private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            //app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"), // TODO ???
            });
            // Plugin the OAuth bearer JSON Web Token tokens generation and Consumption will be here

        }

        // TODO
        private Func<IUserService> CreateUserService(IContainer container)
        {
            return container.Resolve<IUserService>;
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
    }
}