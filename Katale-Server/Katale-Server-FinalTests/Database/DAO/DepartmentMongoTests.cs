using System;
using System.Collections.Generic;
using Katale_Server_.Models;
using Katale_Server_Final.Database.Mongo;
using Katale_Server_Final.Database.Mongo.Implementation;
using Katale_Server_Final.Database.SQL;
using Katale_Server_Final.Service;
using Katale_Server_Final.Service.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;

namespace Katale_Server_FinalTests.Database.DAO
{
    [TestClass]
    public class DepartmentMongoTests
    {

        static IMongoDAO<Department> mongoDAO =new DepartmentMongoDAO();
        IDepartmentService departmentService = new DepartmentService(mongoDAO);
        IDepartmentService departmentService2 = new DepartmentService(new DepartmentSqlDAO());

        [TestMethod]
        public void TestSaveDepartment()
        {
            Department department = new Department("Test Mongo Department", "This is my mongo department");
           
            mongoDAO.Save(department);

            departmentService2.GetAll().ForEach(dpt =>
            {
                mongoDAO.Save(dpt);
            });

        }

        [TestMethod]
        public void TestUpdateDepartment()
        {
            
            Department department = departmentService.GetSingle(2);

            department.Name = "Updated Department";

            departmentService.Update(department);

        }

        [TestMethod]
        public void TestGetAllDepartments()
        {
            List<Department> departments = departmentService.GetAll();

        }

        [TestMethod]
        public void TestDeleteDepartment()
        {
            departmentService.Delete(0);
        }

        [TestMethod]
        public void TestGetSingleDepartment()
        {
            departmentService.GetSingle("Groceries");
        }
    }
}
