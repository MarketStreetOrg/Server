using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Katale_Server_.Database
{
    public static class GlobalConfigurations
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["kataledatabaseazure"].ToString();
            }
        }
    }
}