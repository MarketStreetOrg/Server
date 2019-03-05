using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Utilities
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Entity : System.Attribute
    {
        private string name;

        public string Name { get
            {
                return this.name;
            } }

        public Entity(string name)
        {
            this.name = name;
        }
    }
}