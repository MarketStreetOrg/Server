using Katale_Server_Final.Database.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Neo4j.Driver;
using Neo4j.Driver.V1;

namespace Katale_Server_Final.Database.Neo4j
{
    public abstract class Neo4jDAO
    {
        public IDriver driver { get; }
        public ISession session { get; }

        public Neo4jDAO()
        {
            GlobalConfigurations.Configuration = new LocalNeo4jConfig();

            driver = GraphDatabase.Driver(GlobalConfigurations.ConnectionString, AuthTokens.Basic("root", "root"));

            session = driver.Session();
        }

    }
}