using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katale_Server_Final.Database
{
    public class MongoDAO<T> : IGenericDAO<T>
    {
      
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(T model)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public T GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Save(T model)
        {
            throw new NotImplementedException();
        }

        public void Update(T Model)
        {
            throw new NotImplementedException();
        }
    }
}
