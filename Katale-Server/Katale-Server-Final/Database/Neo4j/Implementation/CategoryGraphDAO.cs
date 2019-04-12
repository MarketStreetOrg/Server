using Katale_Server_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Database.Neo4j.Implementation
{
    public class CategoryGraphDAO : Neo4jDAO, INeo4jDAO<Category>
    {
        public CategoryGraphDAO(): base()
        {

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
            throw new NotImplementedException();
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
            session.Run("CREATE (c:category{name:$name,})",new {category.Name});
        }

        public void Update(Category Model)
        {
            throw new NotImplementedException();
        }
    }
}