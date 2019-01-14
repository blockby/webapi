using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace BBBWebApiCodeFirst.Common
{
    public class ConnectionStringBuilder
    {

        public ConnectionStringBuilder()
        {

        }

        public static string buildConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json")
                               .Build();
            string connectionString = configuration.GetConnectionString("BbbApiConnection");
            return connectionString;
        }
    }
}
