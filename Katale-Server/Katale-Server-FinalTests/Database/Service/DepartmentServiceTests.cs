using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Katale_Server_.Models;
using Katale_Server_Final.Database.SQL;
using Katale_Server_Final.Utilities.AOP;
using Katale_Server_Final.Service.Implementation;
using Katale_Server_Final.Service;

namespace Katale_Server_Final.Database.Tests
{
    [TestClass()]
    public class DepartmentServiceTests
    {
        IDepartmentService departmentService = new DepartmentService(new DepartmentSqlDAO());

        [LoggingAspect]
        [TestMethod()]
        public void TestGetAllDepartments()
        {
            List<Department> departments = departmentService.GetAll();
            Assert.IsNotNull(departmentService.GetAll());

        }

        [TestMethod()]
        public void TestGetSingleDepartment()
        {
            Assert.IsNotNull(departmentService.GetSingle(1));

        }


        [TestMethod()]
        public void TestSaveDepartment()
        {
            Department department = new Department(25, "Automotive", "This is my Automotive department");
            departmentService.Save(department);
            Assert.IsNotNull(departmentService.GetSingle(department));
        }
    }
}