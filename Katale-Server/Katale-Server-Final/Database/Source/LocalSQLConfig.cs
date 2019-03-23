using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Database.Source
{
    public class LocalSQLConfig : IConfig
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["kataledatabase"].ToString();
        }

        public void LoadConfigurations()
        {
            throw new NotImplementedException();
        }
    }
}