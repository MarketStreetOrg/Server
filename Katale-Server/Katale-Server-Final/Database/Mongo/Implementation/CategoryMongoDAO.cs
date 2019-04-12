﻿using Katale_Server_.Models;
using Katale_Server_Final.Utilities.Exceptions;
using MongoDB.Bson;
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

        public bool Exists(Category category)
        {
            return collection.Find(c => c.ID == category.ID).Any();
        }

        public List<Category> GetAll()
        {
            return collection.Find(cat => true).ToList();
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
            if (Exists(category)) throw new RecordExistsException(category.Name);

            collection.InsertOne(category);

        }

        public void Update(Category Model)
        {
            throw new NotImplementedException();
        }
    }
}