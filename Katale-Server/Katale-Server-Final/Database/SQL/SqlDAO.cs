using Katale_Server_.Database;
using Katale_Server_Final.Database.Source;
using System.Data;
using System.Data.SqlClient;

namespace Katale_Server_Final.Database
{
    /**
     *Should be an abstract class that implements the methods from the DAO interface 
     * using SQL and annotated entities 
        */
    public abstract class SqlDAO
    {
        //TODO: Create a connection accessor and use it here
        protected static SqlConnection Con=new SqlConnection();
        protected static SqlCommand Com=new SqlCommand();
        protected static SqlDataAdapter DataAdapter=new SqlDataAdapter();
        protected static SqlDataReader Reader;
        protected string Query;
 
        public SqlDAO()
        {
            GlobalConfigurations.Configuration = new AzureCloudConfig();
        }


        private bool Connected()
        {
            return Con.State == ConnectionState.Open;
        }


        protected SqlConnection CreateConnection()
        {

            Con = new SqlConnection(GlobalConfigurations.ConnectionString);

            if (Connected())
            {
                Con.Close();
            }

            Con.Open();

            return Con;
        }
        
    }
}
