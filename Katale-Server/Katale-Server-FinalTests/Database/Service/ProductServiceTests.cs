using System;
using Katale_Server_.Models;
using Katale_Server_Final.Service;
using Katale_Server_Final.Service.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katale_Server_FinalTests.Database.Service
{
    [TestClass]
    public class ProductServiceTests
    {

        IProductService productService = new ProductService();
        ICategoryService categoryService = new CategoryService();

        [TestMethod]
        public void TestGetAllProducts()
        {
            Assert.IsNotNull(productService.GetAll());
        }

        [TestMethod]
        public void TestGetSingleProduct()
        {
            Assert.IsNotNull(productService.GetSingle(1));
        }

        [TestMethod]
        public void TestUpdateProduct()
        {
            Product product = productService.GetSingle(1);
            product.Name="Updated Product Name";

            Assert.IsNotNull(productService.Update(product));
        }

        [TestMethod()]
        public void TestSaveProduct()
        {
            Category category = categoryService.GetSingle(1);

            Product product = new Product.Builder()
                                       .SetName("Test Product")
                                       .SetDescription("This is my Test Product")
                                       .SetCategory(category)
                                       .IsPromoDepartment(true)
                                       .IsPromoFront(true)
                                       .IsInStock(true)
                                       .Build();

            productService.Save(product);
        }
    }
}
