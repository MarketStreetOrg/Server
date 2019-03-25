using Katale_Server_.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Database.Mongo.Implementation
{
    public class CategoryMongoDAO : MongoDAO, IMongoDAO<Category>
    {
        IMongoCollection<Category> collection; 

        public CategoryMongoDAO()
        {
            collection = mongoDB.GetCollection<Category>("categories");
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Category model)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return collection.Find(cat=>true).ToList();
        }

        public Category GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Category GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Save(Category category)
        {
            try
            {
                collection.InsertOne(category);
            }
            catch
            {

            }
            
        }

        public void Update(Category Model)
        {
            throw new NotImplementedException();
        }
    }
}