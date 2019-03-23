using Katale_Server_Final.Database.Source;

namespace Katale_Server_.Database
{
    public class GlobalConfigurations
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