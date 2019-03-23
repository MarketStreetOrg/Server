using Katale_Server_.Database;
using Katale_Server_.Models;
using Katale_Server_Final.Database.Cloud;
using Katale_Server_Final.Database.Source;
using Katale_Server_Final.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Katale_Server_Final.Database
{
    /**
     *Should be an abstract class that implements the methods from the DAO interface 
     * using SQL and annotated entities 
        */
    public abstract class SqlDAO
    {
        //TODO: Create a connection accessor and use it here
        protected static SqlConnection Con;
        protected static SqlCommand Com;
        protected static SqlDataAdapter DataAdapter;
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

        ///**
        // *Load respective properties from the Domain Object
        // *Used to create mapping to the Current domain object
        // */
        //public Dictionary<PropertyInfo, Column> LoadProperties()
        //{
        //    PropertyInfo[] properties = typeof(T).GetProperties();

        //    Dictionary<PropertyInfo, Column> SelectedProperties = new Dictionary<PropertyInfo, Column>();

        //    properties = properties.Where(p => !(p.GetCustomAttributes().Any(a => a.GetType().Equals(typeof(Transient))))).ToArray();

        //    foreach (PropertyInfo property in properties)
        //    {

        //        String name = property.Name;
        //        Column column = new Column(name,false);

        //        if (property.GetCustomAttributes().Any(a => a.GetType().Equals(typeof(Column))))
        //        {
        //            column = property.GetCustomAttributes<Column>().Select(a => a).First();

        //        }

        //        SelectedProperties.Add(property,column);
        //    }

        //    return SelectedProperties;
        //}

        //public void Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
