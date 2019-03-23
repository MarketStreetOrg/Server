using Katale_Server_.Models;
using Katale_Server_Final.Database;
using Katale_Server_Final.Database.SQL;
using Katale_Server_Final.Utilities.AOP;
using System;
using System.Collections.Generic;

namespace Katale_Server_Final.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        IGenericDAO<Department> DepartmentDAO { get; set; }

        public DepartmentService(IGenericDAO<Department> DataAccessObject)
        {
            this.DepartmentDAO = DataAccessObject;
        }

        public DepartmentService()
        {
            this.DepartmentDAO = new DepartmentSqlDAO();
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
            return this.DepartmentDAO.GetByID(id);
        }

        public Department GetSingle(string Name)
        {
            return this.DepartmentDAO.GetByName(Name);
        }

        [LoggingAspect]
        public List<Department> GetAll()
        {
            return this.DepartmentDAO.GetAll();

        }

        public void Save(Department department)
        {
            this.DepartmentDAO.Save(department);
        }

        public Department GetSingle(Department entity)
        {
            return this.DepartmentDAO.GetByID(entity.ID);
        }

        public void Delete(int id)
        {
            DepartmentDAO.Delete(id);
        }

        public Department Update(Department department)
        {
            DepartmentDAO.Update(department);

            return DepartmentDAO.GetByID(department.ID);
        }

    
    }
}