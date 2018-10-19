using Katale_Server_.Database;
using Katale_Server_.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Katale_Server_.Controllers
{
    public class AdminController : ApiController
    {
        Engine.Departments departments = new Engine.Departments();
        Engine.Categories categories = new Engine.Categories();
        Engine.Products products = new Engine.Products();

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
        public void AddDepartment([FromBody]JObject Department)
        {
            JObject DepartmentObject = Department;

            departments.Add(DepartmentObject["Name"].ToString(), DepartmentObject["Description"].ToString());
        }

        [HttpPut]
        public bool EditDepartment([FromBody]JObject Department)
        {
            try
            {
                JObject DepartmentObject = Department;

                departments.Edit(Convert.ToInt32(DepartmentObject["ID"].ToString()), DepartmentObject["Name"].ToString(), DepartmentObject["Description"].ToString());

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

        [ActionName("Categories-dept")]
        [HttpGet]
        public List<Category> DepartmentCategories(int id)
        {
            return categories.GetByDepartment(id);
        }

        [HttpGet]
        public List<Category> Categories()
        {
            return categories.Get();
        }

        [HttpGet]
        public Category Category(int id)
        {
            return categories.Get(id);
        }

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
    }

}