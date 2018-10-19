using System;
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
        public int Categories { get; set; }

        ///<summary>
        ///Gets Categories from this Department
        ///</summary>
        public List<Category> GetCategories()
        {
            
            return categories.GetByDepartment(ID);
        }



    }
}