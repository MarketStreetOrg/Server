using Katale_Server_.Models;
using Katale_Server_Final.Service;
using Katale_Server_Final.Service.Implementation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Katale_Server_Final.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        IProductService productService = new ProductService();

        //Product functions
        [HttpGet]
        [Route("products")]
        public List<Product> Products()
        {
            return productService.GetAll();
        }

        [HttpGet]
        [Route("product/{id}")]
        public Product Product(int id)
        {
            return productService.GetSingle(id);
        }

        [HttpPost]
        [Route("products/add")]
        public void AddProduct([FromBody] JObject ProductObject)
        {
            ProductObject = new JObject();

            Category category = new Category();
            category.ID = Convert.ToInt32(ProductObject["CategoryID"].ToString());

            Product product = new Product.Builder()
                                        .SetName(ProductObject["Name"].ToString())
                                        .SetDescription(ProductObject["Description"].ToString())
                                        .SetCategory(category)
                                        .IsPromoDepartment(true)
                                        .IsPromoFront(true)
                                        .IsInStock(true)
                                        .Build();

            productService.Save(product);
        }

        [HttpPut]
        [Route("product/{id}/edit")]
        public void EditProduct([FromBody] JObject ProductObject, string id)
        {
            ProductObject = new JObject();

            Category category = new Category();
            category.ID = Convert.ToInt32(ProductObject["CategoryID"].ToString());

            Product product = productService.GetSingle(id);

            product.Name = ProductObject["Name"].ToString();
            product.Description = ProductObject["Description"].ToString();
            product.Category = category;
            product.PromoDept = Convert.ToBoolean(ProductObject["PromoDept"].ToString());
            product.PromoFront = Convert.ToBoolean(ProductObject["PromoFront"].ToString());
            product.InStock = true;

            productService.Update(product);
        }

        [HttpDelete]
        [Route("products/{id}/delete")]
        public void DeleteProduct(int ID)
        {
            productService.Delete(ID);
        }
    }
}