using Katale_Server_Final.Side_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Models
{

    public class Market
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }

        public class Builder
        {
            private Market market = new Market();

            public Builder SetName(string Name)
            {
                market.Name = Name;

                return this;
            }

            public Builder SetDescription(string Description)
            {
                market.Description = Description;

                return this;
            }

            public Builder SetAddress(Address address)
            {
                market.Address = address;

                return this;
            }

            public Market Build()
            {
                return market;
            }
        }
    }
}