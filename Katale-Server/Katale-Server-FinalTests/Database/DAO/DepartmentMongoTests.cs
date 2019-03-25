using System;
using System.Collections.Generic;
using Katale_Server_.Models;
using Katale_Server_Final.Database.Mongo;
using Katale_Server_Final.Database.Mongo.Implementation;
using Katale_Server_Final.Service;
using Katale_Server_Final.Service.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katale_Server_FinalTests.Database.DAO
{
    [TestClass]
    public class DepartmentMongoTests
    {

        static IMongoDAO<Department> mongoDAO =new DepartmentMongoDAO();
        IDepartmentService departmentService = new DepartmentService(mongoDAO);

        [TestMethod]
        public void TestSaveDepartment()
        {
            Department department = new Department("Test Mongo Department", "This is my mongo department");

            mongoDAO.Save(department);

            departmentService.GetAll().ForEach(dpt =>
            {
                mongoDAO.Save(dpt);
            });

        }

        [TestMethod]
        public void TestUpdateDepartment()
        {   
            Department department = new Department("Test for Mongo Department", "This is my Service updated mongo department");
       
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
