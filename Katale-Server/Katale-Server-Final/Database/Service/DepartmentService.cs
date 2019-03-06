using Katale_Server_.Models;
using Katale_Server_Final.Database.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Database
{
    public class DepartmentService :IDepartmentService
    {
        IGenericDAO<Department> DataAccessObject { get; set; }
      
        public DepartmentService(IGenericDAO<Department> DataAccessObject)
        {
            this.DataAccessObject = DataAccessObject;
        }

        public DepartmentService()
        {

        }

        ///<summary>
        ///Gets a single department from the DB using id
        ///
        ///
        ///</summary>
        ///
        ///<param name="id">
        ///</param>
        public Department GetSingle(int id)
        {
            return this.DataAccessObject.GetByID(id);
        }

        public Department GetSingle(string Name)
        {
            return this.DataAccessObject.GetByName(Name);
        }

       
        public List<Department> GetAll()
        {
            return this.DataAccessObject.GetAll();
        }

        public void Save(Department department)
        {
            this.DataAccessObject.Save(department);
        }

        public Department GetSingle(Department entity)
        {
            return this.DataAccessObject.GetByID(entity.ID);
        }
    }
}