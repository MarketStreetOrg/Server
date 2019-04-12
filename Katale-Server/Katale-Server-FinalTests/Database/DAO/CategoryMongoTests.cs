using System;
using Katale_Server_Final.Database.Mongo.Implementation;
using Katale_Server_Final.Database.SQL;
using Katale_Server_Final.Service;
using Katale_Server_Final.Service.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katale_Server_FinalTests.Database.DAO
{
    [TestClass]
    public class CategoryMongoTests
    {
        ICategoryService categoryService = new CategoryService(new CategoryMongoDAO());
        IProductService ProductService = new ProductService(new ProductMongoDAO());
        ICategoryService categoryService2 = new CategoryService(new CategorySqlDAO());
     

        [TestMethod]
        public void TestAddCategory()
        {

            categoryService2.GetAll().ForEach(cat =>
            {
                cat.Products = ProductService.GetAll().FindAll(p => p.Category.ID==cat.ID);

               if(!categoryService.Exists(cat))categoryService.Save(cat);

            });
        }
    }
}
