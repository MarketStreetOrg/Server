using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Utilities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Transient: System.Attribute
    {

    }
}