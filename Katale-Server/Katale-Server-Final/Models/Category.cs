using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Katale_Server_.Database;
using Katale_Server_Final.Utilities;

namespace Katale_Server_.Models
{
    [Entity("categories")]
    public class Category
    {
        Engine.Departments departments = new Engine.Departments();

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Transient]
        public Department Department { get; set; }
        /// <summary>
        /// Returns the number of products within this category
        /// </summary>
        
        [Transient]
        public int Products{ get; set; }

        public Category()
        {
            

        }
           
        
        /////<summary>
        /////Get Department where this category stands
        ///// </summary>
        //public Department GetDepartment()
        //{
        //    return departments.Get(DepartmentID);
        //}

    }
}