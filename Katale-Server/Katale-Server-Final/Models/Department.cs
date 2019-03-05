using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using Katale_Server_.Database;
using Katale_Server_Final.Utilities;

namespace Katale_Server_.Models
{
    [Entity(name:"departments")]
    public class Department
    {

        Engine.Categories categories = new Engine.Categories();
        
        [Column(name:"id", id:true)]
        public int ID { get; set; }
        
        [Column(name:"Name")]
        public string Name { get; set; }
        
        [Column(name:"description")]
        public string Description { get; set; }

        ///<summary>
        ///Returns the number of Categories in the department
        ///</summary>
        [Transient]
        [Column(name:"categories")]
        public int Categories { get; set; }

       [Transient]
        public int Something { get; set; }

        ///<summary>
        ///Gets Categories from this Department
        ///</summary>
        public List<Category> GetCategories()
        {
            
            return categories.GetByDepartment(ID);
        }

        public Department(int Id,string Name, string Description)
        {
            this.ID = Id;
            this.Name = Name;
            this.Description = Description;
        }

        public Department(string Name,string Description)
        {
            this.Name = Name;
            this.Description = Description;
        }

        public Department()
        {

        }
    }
}