using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemMaster.Repository.Context
{
    public class ConnectionStringManager
    {
        public static string GetConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ItemMasterConnection"].ConnectionString;
            return connectionString;
        }
    }
}
