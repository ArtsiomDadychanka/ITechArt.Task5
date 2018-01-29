using Autofac;
using MiniSocialNetwork.Bll.Interfaces;
using MiniSocialNetwork.Bll.Services;
using MiniSocialNetwork.Dal.Interfaces;
using MiniSocialNetwork.Dal.Repositories;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;

namespace MiniSocialNetwork.DIConfig
{
    public static class AutofacConfig
    {
        //private static string connectionString = new 
        //    @"Data Source=.;Initial Catalog=SocialNetwork;Integrated Security=True;providerName=System.Data.SqlClient";
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .WithParameter("connectionString", GetConnectionString());

            builder.RegisterType<UserService>()
                .As<IUserService>();
        }

        private static string GetConnectionString()
        {
            return new SqlConnectionStringBuilder
            {
                InitialCatalog = "SocialNetwork",
                DataSource = ".",
                IntegratedSecurity = true
            }.ConnectionString;
        }
    }
}
