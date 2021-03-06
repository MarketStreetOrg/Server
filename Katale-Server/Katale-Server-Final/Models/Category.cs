﻿using System;
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

        public class Builder
        {
            private Category category=new Category();

            public Builder SetName(string Name)
            {
                category.Name = Name;

                return this;
            }

            public Builder SetDescription(string Description)
            {
                category.Description = Description;

                return this;
            }

            public Builder SetDepartment(Department department)
            {
                category.Department = department;

                return this;
            }

            public Category Build()
            {
                return category;
            }
        }

    }
}