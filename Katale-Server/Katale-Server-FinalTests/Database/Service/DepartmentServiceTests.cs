using Microsoft.VisualStudio.TestTools.UnitTesting;
using Katale_Server_Final.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katale_Server_.Models;
using Katale_Server_Final.Database.Service;
using Katale_Server_Final.Database.SQL;

namespace Katale_Server_Final.Database.Tests
{
    [TestClass()]
    public class DepartmentServiceTests
    {
        IDepartmentService departmentService = new DepartmentService(new DepartmentSqlDAO());

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
            Department department = new Department(25,"Automotive", "This is my Automotive department");
            departmentService.Save(department);
            Assert.IsNotNull(departmentService.GetSingle(department));
        }
    }
}