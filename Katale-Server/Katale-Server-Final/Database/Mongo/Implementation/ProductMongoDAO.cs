using Katale_Server_.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Katale_Server_Final.Database.Mongo.Implementation
{
    public class ProductMongoDAO : MongoDAO, IMongoDAO<Product>
    {
        IMongoCollection<Product> collection;
        BsonDocument document;

        public ProductMongoDAO()
        {
            collection = mongoDB.GetCollection<Product>("products");
        }

        public void Delete(int id)
        {
            collection.DeleteOne(dep => (dep.ID == id));
        }

        public bool Exists(Product Product)
        {
            return collection.Find(dep => true).Any();
        }

        public List<Product> GetAll()
        {
            return collection.Find<Product>(dep => true).ToList();
        }

        public Product GetByID(int id)
        {
            Product Product = collection
                               .Find(dep => dep.ID == id).First();

            return Product;

        }


        public Product GetByName(string name)
        {       
                return collection.Find(dept => dept.Name == name).FirstOrDefault<Product>();          
        }

        public void Save(Product Product)
        {
            collection.InsertOne(Product);
        }

        public async void Update(Product Product)
        {
            document = BsonDocumentWrapper.Create(Product);

            await collection.FindOneAndUpdateAsync(dep => dep.ID == Product.ID, document);

        }
    }
}