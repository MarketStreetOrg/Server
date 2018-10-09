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

                    Con.Close();
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

                    Con.Close();
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

                    Con.Close();
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

                    Con.Close();
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

                    Con.Close();
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

                    Con.Close();
                }
            }

        }

        public class Categories
        {
            /// <summary>
            /// Selecting Categories from Database
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

                    Query = "SelectCategories";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        DataAdapter = new SqlDataAdapter(Com);

                        dt = new DataTable();
                        DataAdapter.Fill(dt);

                    }

                    Con.Close();
                }

                return dt;
            }

            /// <summary>
            /// Selecting categories from Database where Name is .......
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
                    Query = "SelectCategory";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@name", Name));

                        DataAdapter = new SqlDataAdapter(Com);

                        dt = new DataTable();
                        DataAdapter.Fill(dt);

                    }

                    Con.Close();
                }

                return dt;
            }

            /// <summary>
            /// Selecting categories from Database where ID is .......
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
                    Query = "SelectCategory";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@id", ID));

                        DataAdapter = new SqlDataAdapter(Com);

                        dt = new DataTable();
                        DataAdapter.Fill(dt);

                    }

                    Con.Close();
                }

                return dt;
            }


            /// <summary>
            /// Adding Category to Database
            /// </summary>
            public void Add(int CategoryID,string Name, string Description)
            {
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    Query = "AddCategory";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@Departmentid", CategoryID));
                        Com.Parameters.Add(new SqlParameter("@Name", Name));
                        Com.Parameters.Add(new SqlParameter("@Description", Description));

                        Com.ExecuteNonQuery();

                    }

                    Con.Close();
                }
            }

            /// <summary>
            /// Editing Category in Database
            /// </summary>
            public void Edit(int CategoryID,int DepartmentID, string Name, string Description)
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    Query = "UpdateCategory";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@CategoryID", CategoryID));
                        Com.Parameters.Add(new SqlParameter("@DepartmentID", DepartmentID));
                        Com.Parameters.Add(new SqlParameter("@Name", Name));
                        Com.Parameters.Add(new SqlParameter("@Description", Description));

                        Com.ExecuteNonQuery();

                    }

                    Con.Close();
                }
            }

            /// <summary>
            /// Deletes Category from Database
            /// </summary>
            public void Delete(int CategoryID)
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    Query = "DeleteCategory";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@id", CategoryID));


                        Com.ExecuteNonQuery();

                    }

                    Con.Close();
                }
            }
        }

       public class Product
        {
            /// <summary>
            /// Selecting Products from Database
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

                    Query = "SelectProducts";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        DataAdapter = new SqlDataAdapter(Com);

                        dt = new DataTable();
                        DataAdapter.Fill(dt);

                    }

                    Con.Close();
                }

                return dt;
            }

            /// <summary>
            /// Selecting Product from Database where Name is .......
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
                    Query = "SelectProduct";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@name", Name));

                        DataAdapter = new SqlDataAdapter(Com);

                        dt = new DataTable();
                        DataAdapter.Fill(dt);

                    }

                    Con.Close();
                }

                return dt;
            }

            /// <summary>
            /// Selecting product from Database where ID is .......
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
                    Query = "SelectProduct";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@id", ID));

                        DataAdapter = new SqlDataAdapter(Com);

                        dt = new DataTable();
                        DataAdapter.Fill(dt);

                    }

                    Con.Close();
                }

                return dt;
            }


            /// <summary>
            /// Adding Product to Database
            /// </summary>
            public void Add(int CategoryID, string Name, string Description)
            {
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    Query = "AddProduct";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@CategoryID", CategoryID));
                        Com.Parameters.Add(new SqlParameter("@Name", Name));
                        Com.Parameters.Add(new SqlParameter("@Description", Description));

                        Com.ExecuteNonQuery();

                    }

                    Con.Close();
                }
            }

            /// <summary>
            /// Editing product in Database
            /// </summary>
            public void Edit(int CategoryID, int ProductID, string Name, string Description,int PromoFront,int PromoDept)
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    Query = "UpdateProduct";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@CategoryID", CategoryID));
                        Com.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                        Com.Parameters.Add(new SqlParameter("@PromoDept", PromoDept));
                        Com.Parameters.Add(new SqlParameter("@PromoFront", PromoFront));
                        Com.Parameters.Add(new SqlParameter("@Name", Name));
                        Com.Parameters.Add(new SqlParameter("@Description", Description));

                        Com.ExecuteNonQuery();

                    }

                    Con.Close();
                }
            }

            /// <summary>
            /// Deletes product from Database
            /// </summary>
            public void Delete(int CategoryID)
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    Query = "DeleteProduct";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@id", CategoryID));


                        Com.ExecuteNonQuery();

                    }

                    Con.Close();
                }
            }
        
        }

    }
}