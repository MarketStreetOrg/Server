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
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool PromoDept { get; set; }
        public bool PromoFront { get; set; }
        public bool InStock { get; set; }
        public Category Category { get; set; }
        public int ManufacturerID { get; set; }

        Engine.Categories categories = new Engine.Categories();
        Engine.Manufacturers Manufacturers = new Engine.Manufacturers();
        ///<summary>
        ///Gets the manufacturer of this product
        /// </summary>
        public Manufacturer GetManufacturer()
        {
            return Manufacturers.Get(ManufacturerID);

        }

        ///<summary>
        ///Gets the Category in which this product falls
        /// </summary>
        //public Category GetCategory()
        //{
        //    return categories.Get(CategoryID);
        //}

       

    }
}