using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Database.Source
{
    public class LocalNeo4jConfig : IConfig
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Neo4jDb"].ConnectionString.ToString();
        }

        public void LoadConfigurations()
        {
            throw new NotImplementedException();
        }
    }
}