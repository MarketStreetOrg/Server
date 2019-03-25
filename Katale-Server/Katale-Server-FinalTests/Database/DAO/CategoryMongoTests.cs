using System;
using Katale_Server_Final.Database.Mongo.Implementation;
using Katale_Server_Final.Service;
using Katale_Server_Final.Service.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katale_Server_FinalTests.Database.DAO
{
    [TestClass]
    public class CategoryMongoTests
    {
        ICategoryService categoryService = new CategoryService(new CategoryMongoDAO());
        ICategoryService categoryService2 = new CategoryService();

        [TestMethod]
        public void TestAddCategory()
        {
            categoryService2.GetAll().ForEach(cat =>
            {

                categoryService.Save(cat);

            });
        }
    }
}
