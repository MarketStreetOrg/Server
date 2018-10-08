using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Katale_Server_.Database;

namespace Katale_Server_.Models
{
    public class Category
    {
        Engine.Departments departments = new Engine.Departments();

        public int ID { get;}
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentID { get; }
        /// <summary>
        /// Returns the number of products within this category
        /// </summary>
        public int Products{ get;}

        public Category()
        {
            

        }
           
        
        ///<summary>
        ///Get Department where this category stands
        /// </summary>
        public Department GetDepartment()
        {
            DataTable DepartmentTable=departments.Get(DepartmentID);

            Department department = new Department
            {
                ID = Convert.ToInt32(DepartmentTable.Rows[0][0].ToString()),
                Name = DepartmentTable.Rows[0][1].ToString(),
                Description = DepartmentTable.Rows[0][2].ToString()

            };

            return department;
        }

    }
}