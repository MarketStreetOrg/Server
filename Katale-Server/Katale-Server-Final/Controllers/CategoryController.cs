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
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        ICategoryService categoryService = new CategoryService();

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



    }
}