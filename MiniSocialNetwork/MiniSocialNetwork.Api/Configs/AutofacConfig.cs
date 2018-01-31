using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using MiniSocialNetwork.Bll.Interfaces;
using MiniSocialNetwork.Bll.Services;
using MiniSocialNetwork.Dal.Interfaces;
using MiniSocialNetwork.Dal.Repositories;
using MiniSocialNetwork.Shared;

namespace MiniSocialNetwork.Api.Configs
{
    public static class AutofacConfig
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterApiLayer(builder);
            RegisterServices(builder);
            RegisterDlLayer(builder);
        }

        private static void RegisterApiLayer(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();
        }
        private static void RegisterDlLayer(ContainerBuilder builder)
        {
            //builder.RegisterAssemblyTypes(typeof(PostRepository).Assembly)
            //   .Where(t => t.Name.EndsWith("Repository"))
            //   .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .WithParameter("connectionString", SharedConfiguration.ConnectionString)
                .InstancePerRequest();
        }
    }
}