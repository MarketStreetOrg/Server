﻿using Katale_Server_.Database;
using Katale_Server_.Models;
using Katale_Server_Final.Database;
using Katale_Server_Final.Database.Service;
using Katale_Server_Final.Database.SQL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Katale_Server_.Controllers
{
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        Engine.Departments departments = new Engine.Departments();
        Engine.Categories categories = new Engine.Categories();
        Engine.Products products = new Engine.Products();
       // DepartmentService departmentService = new DepartmentService(new DepartmentSqlDAO());
       
        [HttpGet]
        public List<Department> Departments()
        {
        
            return departments.Get();

        }

        [HttpGet]
        public Department Department(int id)
        {
            return departments.Get(id);
        }

   
        [HttpPost]
        [Route("departments/add")]
        public void AddDepartment([FromBody]JObject Department)
        {
            JObject DepartmentObject = Department;

            departments.Add(DepartmentObject["Name"].ToString(), DepartmentObject["Description"].ToString());
        }

        [HttpPut]
        [Route("department/{id}/edit")]
        public bool EditDepartment([FromBody]JObject Department,string id)
        {
            try
            {
                JObject DepartmentObject = Department;

                departments.Edit(Convert.ToInt32(id), DepartmentObject["Name"].ToString(), DepartmentObject["Description"].ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        public bool DeleteDepartment([FromUri]int ID)
        {
            departments.Delete(ID);
            
            return true;
        }

        
        [HttpGet]
        [Route("department/{id}/categories")]
        public List<Category> DepartmentCategories([FromUri]int id)
        {
            return categories.GetByDepartment(id);
        }

        [HttpGet]
        //[Route("categories")]
        public List<Category> Categories()
        {
            return categories.Get();
        }

        [HttpGet]
        public Category Category(int id)
        {
            return categories.Get(id);
        }

        [HttpPost]
        [Route("categories/add")]
        public void AddCategory([FromBody]JObject Category)
        {
            JObject CategoryObject = Category;

            categories.Add(Convert.ToInt32(CategoryObject["Departmentid"].ToString()),CategoryObject["Name"].ToString(), CategoryObject["Description"].ToString());
        }

       
        [HttpPut]
        [Route("categories/{id}/edit")]
        public void EditCategory([FromBody] JObject Category,[FromUri]String id)
        {
            JObject CategoryObject = Category;
           
            categories.Edit(Convert.ToInt32(id), Convert.ToInt32(CategoryObject["Departmentid"].ToString()), CategoryObject["Name"].ToString(), CategoryObject["Description"].ToString());
        }
        
        [HttpDelete]
        [Route("categories/{id}/delete")]
        public void DeleteCategory(int id)
        {
            categories.Delete(id);
        }
        
       
        //Product functions
        [HttpGet]
        public List<Product> Products()
        {
            return products.Get();
        }

        [HttpGet]
        public Product Product(int id)
        {
            return products.Get(id);
        }
        
        [HttpPost]
        [Route("products/add")]
        public void AddProduct([FromBody] JObject ProductObject)
        {
            ProductObject = new JObject();

            products.Add(Convert.ToInt32(ProductObject["CategoryID"].ToString()), ProductObject["Name"].ToString(), ProductObject["Description"].ToString());
        }

        [HttpPut]
        [Route("products/{id}/edit")]
        public void EditProduct([FromBody] JObject ProductObject,string id)
        {
            ProductObject = new JObject();
            
            products.Edit(Convert.ToInt32(id), Convert.ToInt32(ProductObject["ProductID"].ToString()), ProductObject["Name"].ToString(), ProductObject["Description"].ToString(),Convert.ToInt32(ProductObject["PromoFront"].ToString()), Convert.ToInt32(ProductObject["PromoDept"].ToString()));
        }

        [HttpDelete]
        [Route("products/{id}/delete")]
        public void DeleteProduct(int ID)
        {
            products.Delete(ID);
        }

        //Market Functions
        [HttpGet]
        public void Markets()
        {
            
        }
    }

}