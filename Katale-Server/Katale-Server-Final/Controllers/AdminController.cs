﻿using Katale_Server_.Database;
using Katale_Server_.Models;
using Katale_Server_Final.Database.SQL;
using Katale_Server_Final.Service;
using Katale_Server_Final.Service.Implementation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Katale_Server_.Controllers
{
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {

        Engine.Products products = new Engine.Products();
        IDepartmentService departmentService = new DepartmentService();
        ICategoryService categoryService = new CategoryService();
        IProductService productService = new ProductService();

        [HttpGet]
        public List<Department> Departments()
        {
            return departmentService.GetAll();

        }

        [HttpGet]
        public Department Department(int id)
        {
            return departmentService.GetSingle(id);
        }


        [HttpPost]
        [Route("departments/add")]
        public void AddDepartment([FromBody]JObject Department)
        {
            JObject DepartmentObject = Department;

            Department department = new Department(DepartmentObject["Name"].ToString(), DepartmentObject["Description"].ToString());

            departmentService.Save(department);
        }

        [HttpPut]
        [Route("department/{id}/edit")]
        public Department EditDepartment([FromBody]JObject Department, string id)
        {
            try
            {
                JObject DepartmentObject = Department;
                Department department = new Department(DepartmentObject["Name"].ToString(), DepartmentObject["Description"].ToString());

                return departmentService.Update(department);

            }
            catch
            {
                return null;
            }
        }

        [HttpDelete]
        public void DeleteDepartment([FromUri]int ID)
        {
            departmentService.Delete(ID);
        }


        [HttpGet]
        [Route("department/{id}/categories")]
        public List<Category> DepartmentCategories([FromUri]int id)
        {
            return null;
            //return departmentSqlDao.GetSingle(id); 
        }

        [HttpGet]
        //[Route("categories")]
        public List<Category> Categories()
        {
            return categoryService.GetAll();
        }

        [HttpGet]
        public Category Category(int id)
        {
            return categoryService.GetSingle(id);
        }

        [HttpPost]
        [Route("categories/add")]
        public void AddCategory([FromBody]JObject Category)
        {
            JObject CategoryObject = Category;

            Department department = new Department();
            department.ID = Convert.ToInt32(CategoryObject["Departmentid"].ToString());

            Category category = new Category.Builder()
                                          .SetName(CategoryObject["Name"].ToString())
                                          .SetDescription(CategoryObject["Description"].ToString())
                                          .SetDepartment(department)
                                          .Build();

            categoryService.Save(category);

        }


        [HttpPut]
        [Route("categories/{id}/edit")]
        public void EditCategory([FromBody] JObject Category, [FromUri]String id)
        {
            JObject CategoryObject = Category;

            Department department = new Department();
            department.ID = Convert.ToInt32(CategoryObject["Departmentid"].ToString());

            Category category = new Category.Builder()
                                         .SetName(CategoryObject["Name"].ToString())
                                         .SetDescription(CategoryObject["Description"].ToString())
                                         .SetDepartment(department)
                                         .Build();

            categoryService.Update(category);
        }

        [HttpDelete]
        [Route("categories/{id}/delete")]
        public void DeleteCategory(int id)
        {
            categoryService.Delete(id);
        }


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

        //Market Functions
        [HttpGet]
        public void Markets()
        {

        }
    }

}