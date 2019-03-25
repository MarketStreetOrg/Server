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
    public class DepartmentMongoDAO : MongoDAO, IMongoDAO<Department>
    {
        IMongoCollection<Department> collection;
        BsonDocument document;
        
        public DepartmentMongoDAO()
        {
            collection = mongoDB.GetCollection<Department>("departments");
        }

        public void Delete(int id)
        {
            collection.DeleteOne(dep => (dep.ID == id));
        }

        public bool Exists(Department department)
        {
            return collection.Find(dep => true).Any();
        }

        public List<Department> GetAll()
        {

            return collection.Find<Department>(dep => true).ToList();
        }

        public Department GetByID(int id)
        {
            Department department = collection
                               .Find(dep => dep.ID == id).First();

            return department;

        }


        public Department GetByName(string name)
        {
            return collection.Find(dept => dept.Name == name).First();
        }

        public async void Save(Department department)
        {

            await collection.InsertOneAsync(department);
        }

        public async void Update(Department department)
        {
            document = BsonDocumentWrapper.Create(department);

            await collection.FindOneAndUpdateAsync(dep => dep.ID == department.ID, document);

        }
    }
}