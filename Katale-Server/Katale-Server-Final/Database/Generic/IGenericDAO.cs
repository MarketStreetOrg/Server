using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katale_Server_Final.Database
{
   public interface IGenericDAO <T>
    {
        List<T> GetAll();
        T GetByID(int id);
        T GetByName(string name);
        void Save(T model);
        void Update(T Model);
        void Delete(int id);
        Boolean Exists(T model);
        
    }
}
