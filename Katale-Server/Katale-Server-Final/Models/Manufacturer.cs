using Katale_Server_Final.Models;
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
        
        public Address Address { get; set; }

        public class Builder
        {
            private Manufacturer manufacturer = new Manufacturer();

            public Builder SetName(string Name)
            {
                manufacturer.Name = Name;

                return this;
            }

            public Builder SetLogo(string Logo)
            {
                manufacturer.Logo = Logo;

                return this;
            }

            public Builder SetAddress(Address address)
            {
                manufacturer.Address = address;

                return this;
            }

            public Manufacturer Build()
            {
                return manufacturer;
            }
        }

    }
}