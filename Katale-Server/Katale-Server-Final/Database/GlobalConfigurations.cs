using Katale_Server_Final.Database.Source;

namespace Katale_Server_Final.Database
{
    public static class GlobalConfigurations
    {

        public static IConfig Configuration { get; set; }
        

        public static string ConnectionString
        {
            get
            {
                return Configuration.GetConnectionString();

            }
        }
    }
}