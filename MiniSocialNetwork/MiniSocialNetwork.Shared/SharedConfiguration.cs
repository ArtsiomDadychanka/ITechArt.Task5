using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSocialNetwork.Shared
{
    public static class SharedConfiguration
    {
        static SharedConfiguration()
        {
            ConnectionString = new SqlConnectionStringBuilder
            {
                InitialCatalog = "SocialNetwork",
                DataSource = ".",
                IntegratedSecurity = true
            }.ConnectionString;
        }

        public static String ConnectionString { get; } 
    }
}
