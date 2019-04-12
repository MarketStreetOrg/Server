using System.Collections.Generic;
using Katale_Server_.Models;
using Katale_Server_Final.Database.Mongo;
using Katale_Server_Final.Database.Mongo.Implementation;
using Katale_Server_Final.Database.SQL.Implementation;
using Katale_Server_Final.Service;
using Katale_Server_Final.Service.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katale_Server_FinalTests.Database.DAO
{
    [TestClass]
    public class ProductMongoTests
    {

        static IMongoDAO<Product> mongoDAO =new ProductMongoDAO();
        IProductService ProductService = new ProductService(mongoDAO);
        IProductService ProductService2 = new ProductService(new ProductSqlDAO());

        [TestMethod]
        public void TestSaveProduct()
        {
            ProductService2.GetAll().ForEach(p =>
            {
             if(!mongoDAO.Exists(p)) mongoDAO.Save(p);
            });

        }

        [TestMethod]
        public void TestUpdateProduct()
        {
            
            Product Product = ProductService.GetSingle(2);

            Product.Name = "Updated Product";

            ProductService.Update(Product);

        }

        [TestMethod]
        public void TestGetAllProducts()
        {
            List<Product> Products = ProductService.GetAll();

        }

        [TestMethod]
        public void TestDeleteProduct()
        {
            ProductService.Delete(0);
        }

        [TestMethod]
        public void TestGetSingleProduct()
        {
            ProductService.GetSingle("Matook");
        }
    }
}
