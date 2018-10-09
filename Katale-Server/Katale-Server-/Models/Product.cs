using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Katale_Server_.Database;

namespace Katale_Server_.Models
{
    public class Product
    {

        public int ID { get;}
        public string Name { get; set; }
        public string Description { get; set; }
        public bool PromoDept { get; set; }
        public bool PromoFront { get; set; }
        public bool InStock { get;}
        private int CategoryID { get; set; }

        Engine.Categories categories = new Engine.Categories();

        ///<summary>
        ///Gets the manufacturer of this product
        /// </summary>
        public Manufacturer GetManufacturer()
        {

        }

        ///<summary>
        ///Gets the Category in which this product falls
        /// </summary>
        public Category GetCategory()
        {

            DataTable dt = new DataTable();

            dt= categories.Get(CategoryID);

            Category cat = new Category
            {
                ID = Convert.ToInt32(dt.Rows[0][0]),
                Name = dt.Rows[0][1].ToString(),
                Description = dt.Rows[0][2].ToString(),
                DepartmentID = Convert.ToInt32(dt.Rows[0][3]),
                Products = Convert.ToInt32(dt.Rows[0][5])

            };

            return cat;
        }

       

    }
}