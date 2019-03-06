using Katale_Server_Final.Database.Cloud;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Katale_Server_.Database
{
    public static class GlobalConfigurations
    {
        public static IConfig Configuration { get; set; }
        
     
        public static string CloudConnectionString
        {
            get
            {
                return Configuration.GetConnectionString();
            }
        }
        
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["azurekataledatabase"].ToString();
            }
        }
    }
}