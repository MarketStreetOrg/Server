using Katale_Server_.Database;
using Katale_Server_.Models;
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

    }

}