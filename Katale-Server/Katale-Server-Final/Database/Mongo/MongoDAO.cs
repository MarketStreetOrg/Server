using Katale_Server_Final.Database.Source;
using MongoDB.Driver;

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

            mongoDB = mongoClient.GetDatabase("katale_product_catalog", null);
        }

    }
}
