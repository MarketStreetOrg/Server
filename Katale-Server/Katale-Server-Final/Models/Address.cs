using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Models
{
    public class Address
    {
        public int ID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkNumber { get; set; }

        public class Builder
        {
            Address address = new Address();

            public Builder SetEmail(string Email)
            {
                address.Email = Email;

                return this;
            }
            

            public Builder SetPhoneNumber(string PhoneNumber)
            {
                address.PhoneNumber = PhoneNumber;

                return this;
            }

            public Builder SetWorkNumber(string WorkNumber)
            {
                address.WorkNumber = WorkNumber;

                return this;
            }

            public Builder SetPrimaryAddress(string PrimaryAddress)
            {
                address.Address1 = PrimaryAddress;

                return this;
            }

            public Builder SetSecondaryAddress(string SecondaryAddress)
            {
                address.Address2= SecondaryAddress;

                return this;
            }

            public Address Build()
            {
                return address;
            }
        }
    }
}