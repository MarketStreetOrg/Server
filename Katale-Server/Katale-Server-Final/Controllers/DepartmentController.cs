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
    [RoutePrefix("api/department")]
    public class DepartmentController : ApiController
    {
        IDepartmentService departmentService = new DepartmentService();

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

    }
}