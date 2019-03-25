using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Utilities
{
    public static class PropertyConfigurations
    {
        static IniFile ini = new IniFile(ConfigurationManager.AppSettings["IniPath"].ToString());
            
        public static void Write(string key, string value, string section = null)
        {
            ini.Write(key, value, section);
        }

        public static string Read(string key,string section = null)
        {
            return ini.Read(key, section);
        }

        
    }
}