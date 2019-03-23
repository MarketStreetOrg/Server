using Katale_Server_Final.Service;
using Katale_Server_Final.Service.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katale_Server_FinalTests.Database
{
    [TestClass()]
    class ServiceTest
    {

        IDepartmentService DepartmentService = new DepartmentService();

        [TestMethod()]
        public void DepartmentServiceTest()
        {

            DepartmentService.GetAll();

        }

    }
}
