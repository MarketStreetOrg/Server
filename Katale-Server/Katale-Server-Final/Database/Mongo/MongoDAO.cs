using Katale_Server_.Database;
using Katale_Server_Final.Database.Source;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katale_Server_Final.Database
{
    public abstract class MongoDAO
    {
        public MongoClient mongoClient { get; }
        public IMongoDatabase mongoDB { get; }
        

        public MongoDAO()
        {
            GlobalConfigurations.Configuration = new LocalMongoDBConfig();

            mongoClient = new MongoClient(GlobalConfigurations.ConnectionString);

            mongoDB = mongoClient.GetDatabase("Katale", null);
        }

    }
}
