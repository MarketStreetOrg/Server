using Katale_Server_.Database;
using Katale_Server_.Models;
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

    //    //Get Model Entity Attribute
    //    System.Reflection.MemberInfo memberInfo = typeof(T);

    //    private Entity entity = null;
    //    private Dictionary<PropertyInfo, Column> columns = null;

    //    public SqlDAO()
    //    {
    //        if (memberInfo.GetCustomAttribute<Entity>() != null)
    //        {
    //            entity = (Entity)memberInfo.GetCustomAttributes(true).Select(a => a)
    //            .Where(a => a.GetType() == typeof(Entity))
    //            .Aggregate((a, b) => a = b);
    //        }

    //        else
    //        {
    //            entity = new Entity(memberInfo.Name);
    //        }

    //        columns = LoadProperties();

    //    }


    //    public bool Exists(T model)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<T> GetAll()
    //    {
    //        List<T> elements = new List<T>();

    //        CreateConnection();

    //        Query = "Select * from " + entity.Name;

    //        using (Com = new SqlCommand(Query, Con))
    //        {

    //            DataAdapter = new SqlDataAdapter(Com);

    //            DataTable dataTable = new DataTable();
    //            DataAdapter.Fill(dataTable);

    //            foreach (DataRow dataRow in dataTable.Rows)
    //            {
    //                T domainObject = (T)Activator.CreateInstance(typeof(T));

    //                foreach (var DomainObject in columns)
    //                {
    //                    if (dataRow[DomainObject.Value.Name] != DBNull.Value)
    //                    {
    //                        DomainObject.Key.SetValue(domainObject, dataRow[DomainObject.Value.Name]);
    //                    }
    //                }

    //                elements.Add(domainObject);
    //            }

    //            Com.Dispose();

    //        }

    //        Con.Close();

    //        return elements;
    //    }

    //    public List<T> GetByQuery(string Query)
    //    {
    //        List<T> elements = new List<T>();

    //        CreateConnection();

    //        using (Com = new SqlCommand(Query, Con))
    //        {

    //            DataAdapter = new SqlDataAdapter(Com);

    //            DataTable dataTable = new DataTable();
    //            DataAdapter.Fill(dataTable);

    //            foreach (DataRow dataRow in dataTable.Rows)
    //            {
    //                T domainObject = (T)Activator.CreateInstance(typeof(T));

    //                foreach (var DomainObject in columns)
    //                {

    //                    DomainObject.Key.SetValue(domainObject, dataRow[DomainObject.Value.Name]);
    //                }

    //                elements.Add(domainObject);
    //            }

    //            Com.Dispose();

    //        }

    //        Con.Close();

    //        return elements;
    //    }

    //    //public List<T> GetAllWithStoredProcedure(string Query)
    //    //{
    //    //    List<T> elements = new List<T>();

    //    //    using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
    //    //    {

    //    //        if (Connected())
    //    //        {
    //    //            Con.Close();
    //    //        }

    //    //        Con.Open();

    //    //        Com = new SqlCommand(Query, Con);

    //    //        Com.CommandType = CommandType.StoredProcedure;

    //    //        DataAdapter = new SqlDataAdapter(Com);

    //    //        DataTable dataTable = new DataTable();
    //    //        DataAdapter.Fill(dataTable);

    //    //        foreach (DataRow dataRow in dataTable.Rows)
    //    //        {
    //    //            T domainObject = (T)Activator.CreateInstance(typeof(T));

    //    //            foreach (var DomainObject in columns)
    //    //            {

    //    //                DomainObject.Key.SetValue(domainObject, dataRow[DomainObject.Value]);
    //    //            }

    //    //            elements.Add(domainObject);
    //    //        }

    //    //        Com.Dispose();

    //    //    }

    //    //    Con.Close();

    //    //    return elements;

    //    //}

    //    public T GetByID(int id)
    //    {

    //        T domainObject = (T)Activator.CreateInstance(typeof(T));

    //        CreateConnection();

    //        Query = "Select * from " + entity.Name + " where "
    //            + columns.Select(p => p.Value)
    //            .Where(v => v.ID).Select(v=>v.Name).First() + "='" + id + "'";

    //        using (Com = new SqlCommand(Query, Con))
    //        {

    //            DataAdapter = new SqlDataAdapter(Com);

    //            DataTable dataTable = new DataTable();
    //            DataAdapter.Fill(dataTable);
                
    //            foreach (var DomainObject in columns)
    //            {
    //                if (dataTable.Rows[0][DomainObject.Value.Name] != DBNull.Value)
    //                {
    //                    DomainObject.Key.SetValue(domainObject, dataTable.Rows[0][DomainObject.Value.Name]);
    //                }
    //            }

    //            Com.Dispose();

    //        }

    //        Con.Close();

    //        return domainObject;
    //    }

    //    public T GetByName(string name)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public T GetFromQuery(string Query)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Save(T model)
    //    {
    //        this.CreateConnection();

    //        Query = "AddDepartment";

    //        using (Com = new SqlCommand(Query, Con))
    //        {
    //            Com.CommandType = CommandType.StoredProcedure;

    //            //Com.Parameters.Add(new SqlParameter("@Name", Name));
    //            //Com.Parameters.Add(new SqlParameter("@Description", Description));

    //            foreach(Column column in columns.Values)
    //            {
    //                Com.Parameters.Add(new SqlParameter('@'+column.Name,columns
    //                    .Where(p=>p.Value.Equals(column)).Select(p=>p.Key.GetValue())))
    //            }


    //            Com.ExecuteNonQuery();

    //        }

    //        Con.Close();
        
    //}

    //    public void Update(T Model)
    //    {
    //        throw new NotImplementedException();
    //    }

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
