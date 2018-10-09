﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using Katale_Server_.Database;

namespace Katale_Server_.Models
{
    public class Department
    {

        Engine.Categories categories = new Engine.Categories();
        

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        ///<summary>
        ///Returns the number of Categories in the department
        ///</summary>
        private int Categories { get; set; }

        ///<summary>
        ///Gets Categories from this Department
        ///</summary>
        public List<Category> GetCategories()
        {
            List<Category> ls = new List<Category>();

            foreach(DataRow dr in categories.Get().Rows)
            {
                Category category = new Category
                {
                    ID = Convert.ToInt32(dr[0].ToString()),
                    Name = dr[1].ToString(),
                    Description = dr[2].ToString(),
                    DepartmentID = Convert.ToInt32(dr[3].ToString()),
                    Products=Convert.ToInt32(dr[5].ToString())
                };

                ls.Add(category);
            }

            return ls;
        }



    }
}