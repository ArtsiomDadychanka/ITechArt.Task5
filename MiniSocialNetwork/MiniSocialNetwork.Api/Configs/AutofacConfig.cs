using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using MiniSocialNetwork.Api.Providers;
using MiniSocialNetwork.Bll.Interfaces;
using MiniSocialNetwork.Bll.Services;
using MiniSocialNetwork.Dal.EF;
using MiniSocialNetwork.Dal.Interfaces;
using MiniSocialNetwork.Dal.Repositories;
using MiniSocialNetwork.Shared;
using MiniSocialNetwork.Web.Hubs;

namespace MiniSocialNetwork.Api.Configs
{
    public static class AutofacConfig
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<ChatHub>()
                .AsSelf();

            RegisterApiLayer(builder);
            RegisterServices(builder);
            RegisterDlLayer(builder);
        }

        private static void RegisterApiLayer(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<AuthorizationServerProvider>()
                .AsSelf();

            builder.RegisterType<Startup>()
                .AsSelf()
                .PropertiesAutowired();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(AuthService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
            //.InstancePerRequest();
        }
        private static void RegisterDlLayer(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationContext>()
                .AsSelf()
                .WithParameter("connectionString", SharedConfiguration.ConnectionString);
                //.InstancePerRequest();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>();
            //.InstancePerRequest();
        }
    }
}