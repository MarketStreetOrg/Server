using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katale_Server_Final.Database
{
    interface ISqlDAO<T> : IGenericDAO<T>
    {
        //void CreateQuery(string Query);
        //T GetFromQuery(string Query);    
        List<T> GetByQuery(string Query);
        
    }
}
