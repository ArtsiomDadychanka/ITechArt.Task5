using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSocialNetwork.Shared
{
    public static class SharedConfiguration
    {
        static SharedConfiguration()
        {
            ConnectionString =
                @"Data Source=(localdb)\v17.0;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True;";
        }

        public static String ConnectionString { get; } 
    }
}
