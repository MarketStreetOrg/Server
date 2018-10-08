using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;


namespace Katale_Server_.Database
{
    public class Engine
    { 
        protected static SqlConnection Con;
        protected static SqlCommand Com;
        protected static SqlDataAdapter DataAdapter;
        protected static SqlDataReader Reader;
        protected static string Query;

        public class Departments
        {

            /// <summary>
            /// Selecting Departments from Database
            /// </summary>
            public DataTable Get()
            {
                DataTable dt = null;
                
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }

                    Query = "SelectDepartments";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        DataAdapter = new SqlDataAdapter(Com);

                        dt = new DataTable();
                        DataAdapter.Fill(dt);
                        
                    }
                }

                return dt;
            }

            /// <summary>
            /// Selecting Departments from Database where Name is .......
            /// </summary>
            public DataTable Get(string Name)
            {
                DataTable dt = null;

                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    Query = "SelectDepartment";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@name", Name));

                        DataAdapter = new SqlDataAdapter(Com);

                        dt = new DataTable();
                        DataAdapter.Fill(dt);

                    }
                }

                return dt;
            }

            /// <summary>
            /// Selecting Departments from Database where ID is .......
            /// </summary>
            public DataTable Get(int ID)
            {
                DataTable dt = null;

                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    Query = "SelectDepartment";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@id", ID));

                        DataAdapter = new SqlDataAdapter(Com);

                        dt = new DataTable();
                        DataAdapter.Fill(dt);

                    }
                }

                return dt;
            }


            /// <summary>
            /// Adding Department to Database
            /// </summary>
            public void Add(string Name,string Description)
            {
                using (Con=new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    Query = "AddDepartment";

                    using (Com=new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@Name", Name));
                        Com.Parameters.Add(new SqlParameter("@Description", Description));

                        Com.ExecuteNonQuery();

                    }
                }
            }

            /// <summary>
            /// Editing Department in Database
            /// </summary>
            public void Edit(int DepartmentID,string Name,string Description)
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    Query = "UpdateDepartment";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@DepartmentID", DepartmentID));
                        Com.Parameters.Add(new SqlParameter("@Name", Name));
                        Com.Parameters.Add(new SqlParameter("@Description", Description));

                        Com.ExecuteNonQuery();

                    }
                }
            }

            /// <summary>
            /// Deletes Department from Database
            /// </summary>
            public void Delete(int DepartmentID)
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    Query = "DeleteDepartment";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@id", DepartmentID));
                     

                        Com.ExecuteNonQuery();

                    }
                }
            }

        }

        public class Categories
        {

        }

    }
}