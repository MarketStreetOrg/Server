using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        }

       

    }
}