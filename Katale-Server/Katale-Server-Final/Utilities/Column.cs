using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Utilities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Column : System.Attribute
    {
        private string name;
        private bool id;

        public bool ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public Column(string name)
        {
            this.name = name;
        }

        public Column(string name,bool id)
        {
            this.name = name;
            this.id = id;
        }
    }
}