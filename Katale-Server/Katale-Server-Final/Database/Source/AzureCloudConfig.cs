using Katale_Server_Final.Database.Source;
using Katale_Server_Final.Utilities;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Katale_Server_Final.Database.Source
{
    public class AzureCloudConfig : IConfig
    {

        private string CloudConnectionString;

        public AzureCloudConfig()
        {
            LoadConfigurations();
        }

        public string GetConnectionString()
        {
             return CloudConnectionString;
         
        }

        public void LoadConfigurations()
        {
            string cs=ConfigurationManager.ConnectionStrings["kataledatabaseazure"].ConnectionString.ToString();

            IniFile InitializationFile = new IniFile(ConfigurationManager.AppSettings["IniPath"]);

            InitializationFile.Write("username", "steven");
            InitializationFile.Write("Password", "Password@2019");

            string UserName = InitializationFile.Read("username");
            string Password = InitializationFile.Read("Password");

            CloudConnectionString = String.Format(cs, UserName, Password);

        }
    }
}