using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Katale_Server_.Models
{
    public class Manufacturer
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string PrimaryAddress { get; set; }
        public string SecondaryAddress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkNumber { get; set; }

    }
}