using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using Katale_Server_.Models;
using Katale_Server_Final.Models;
using Katale_Server_Final.Side_Code;
using System.IO;
using Katale_Server_Final.Database.Cloud;

namespace Katale_Server_.Database
{
    public class Engine
    {
        protected static SqlConnection Con;
        protected static SqlCommand Com;
        protected static SqlDataAdapter DataAdapter;
        protected static SqlDataReader Reader;
        protected static string Query;

        Categories categories = new Categories();

       
        public class Departments
        {
            /// <summary>
            /// Selecting Departments from Database
            /// </summary>
            /// 
            

            List<Department> departments = new List<Department>();

            string GetDepartments()
            {
                return departments.Select(x => x).Where(x => x.Name == "").Select(x => x.Name).Aggregate((a, b) => a + b);
            }

            public List<Department> Get()
            {

                List<Department> departments = new List<Department>();

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

                        foreach (DataRow dataRow in dt.Rows)
                        {
                            Department department = new Department
                            {
                                ID = Convert.ToInt32(dataRow[0].ToString()),
                                Name = dataRow[1].ToString(),
                                Description = dataRow[2].ToString(),
                                Categories = Convert.ToInt32(dataRow[3].ToString())

                            };

                            departments.Add(department);
                        }

                    }

                    Con.Close();
                }

                return departments;
            }

            /// <summary>
            /// Selecting Departments from Database where Name is .......
            /// </summary>
            public Department Get(string Name)
            {
                Department department = new Department();

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

                        department.ID = Convert.ToInt32(dt.Rows[0][0].ToString());
                        department.Name = dt.Rows[0][1].ToString();
                        department.Description = dt.Rows[0][2].ToString();

                    }

                    Con.Close();
                }

                return department;
            }

            /// <summary>
            /// Selecting Departments from Database where ID is .......
            /// </summary>
            public Department Get(int ID)
            {

                Department department = new Department();

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

                        department.ID = Convert.ToInt32(dt.Rows[0][0].ToString());
                        department.Name = dt.Rows[0][1].ToString();
                        department.Description = dt.Rows[0][2].ToString();

                    }

                    Con.Close();
                }

                return department;
            }

            /// <summary>
            /// Adding Department to Database
            /// </summary>
            public void Add(string Name, string Description)
            {
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    Query = "AddDepartment";

                    using (Com = new SqlCommand(Query, Con))
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
            public void Edit(int DepartmentID, string Name, string Description)
            {

                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }

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

                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }

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
            public List<Category> Get()
            {
                DataTable dt = null;
                List<Category> categories = new List<Category>();

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

                        foreach (DataRow dataRow in dt.Rows)
                        {
                            Category category = new Category
                            {
                                ID = Convert.ToInt32(dataRow[0].ToString()),
                                Name = dataRow[1].ToString(),
                                Description = dataRow[2].ToString(),
                                Department = new Departments().Get(Convert.ToInt32(dataRow[3].ToString())),
                                Products = Convert.ToInt32(dataRow[5])

                            };

                            categories.Add(category);
                        }

                    }

                    Con.Close();
                }

                return categories;
            }

            /// <summary>
            /// Selecting categories from Database where Name is .......
            /// </summary>
            public Category Get(string Name)
            {
                DataTable dt = null;

                Category category = new Category();

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

                        category = new Category
                        {
                            ID = Convert.ToInt32(dt.Rows[0][0].ToString()),
                            Name = dt.Rows[0][1].ToString(),
                            Description = dt.Rows[0][2].ToString(),
                            Department = new Departments().Get(Convert.ToInt32(dt.Rows[0][3].ToString())),
                            Products = Convert.ToInt32(dt.Rows[0][5])

                        };

                    }

                    Con.Close();
                }

                return category;
            }

            /// <summary>
            /// Selecting categories from Database where ID is .......
            /// </summary>
            public Category Get(int ID)
            {
                DataTable dt = null;

                Category category = new Category();

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

                        category = new Category
                        {
                            ID = Convert.ToInt32(dt.Rows[0][0].ToString()),
                            Name = dt.Rows[0][1].ToString(),
                            Description = dt.Rows[0][2].ToString(),
                            Department = new Departments().Get(Convert.ToInt32(dt.Rows[0][3].ToString())),
                            Products = Convert.ToInt32(dt.Rows[0][5])

                        };

                    }

                    Con.Close();
                }

                return category;
            }

            /// <summary>
            /// Selecting Categories from Database by DepartmentID
            /// </summary>
            public List<Category> GetByDepartment(int DepartmentID)
            {
                DataTable dt = null;
                List<Category> categories = new List<Category>();

                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }

                    Query = "SelectCategoriesByDepartment";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@DepartmentID", DepartmentID));

                        DataAdapter = new SqlDataAdapter(Com);

                        dt = new DataTable();
                        DataAdapter.Fill(dt);

                        foreach (DataRow dataRow in dt.Rows)
                        {
                            Category category = new Category
                            {
                                ID = Convert.ToInt32(dataRow[0].ToString()),
                                Name = dataRow[1].ToString(),
                                Description = dataRow[2].ToString(),
                                Department = new Departments().Get(Convert.ToInt32(dataRow[3].ToString())),
                                Products = Convert.ToInt32(dataRow[5])

                            };

                            categories.Add(category);
                        }

                    }

                    Con.Close();
                }

                return categories;
            }



            /// <summary>
            /// Adding Category to Database
            /// </summary>
            public void Add(int DepartmentID, string Name, string Description)
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

                        Com.Parameters.Add(new SqlParameter("@Departmentid", DepartmentID));
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
            public void Edit(int CategoryID, int DepartmentID, string Name, string Description)
            {
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
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

        public class Products
        {
            /// <summary>
            /// Selecting Products from Database
            /// </summary>
            public List<Product> Get()
            {
                DataTable dt = null;

                List<Product> products = new List<Product>();

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

                        foreach (DataRow dataRow in dt.Rows)
                        {

                            Product product = new Product
                            {

                                ID = Convert.ToInt32(dataRow[0].ToString()),
                                Name = dataRow[1].ToString(),
                                Description = dataRow[4].ToString(),
                                PromoDept = Convert.ToBoolean(dataRow[2]),
                                PromoFront = Convert.ToBoolean(dataRow[3]),
                                InStock = Convert.ToBoolean(dataRow[8]),
                                Category = new Categories().Get(Convert.ToInt32(dataRow[6].ToString())),



                            };

                            if (!dataRow[5].Equals(DBNull.Value))
                            {
                                product.ManufacturerID = Convert.ToInt32(dataRow[5].ToString());
                            }

                            products.Add(product);

                        }


                    }

                    Con.Close();
                }

                return products;
            }

            /// <summary>
            /// Selecting Product from Database where Name is .......
            /// </summary>
            public Product Get(string Name)
            {
                DataTable dt = null;
                Product product = new Product();

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

                        product = new Product
                        {
                            ID = Convert.ToInt32(dt.Rows[0][0].ToString()),
                            Name = dt.Rows[0][1].ToString(),
                            Description = dt.Rows[0][4].ToString(),
                            PromoDept = Convert.ToBoolean(dt.Rows[0][2]),
                            PromoFront = Convert.ToBoolean(dt.Rows[0][3]),
                            InStock = Convert.ToBoolean(dt.Rows[0][8]),
                            Category = new Categories().Get((dt.Rows[0][6].ToString()))

                        };

                        if (!dt.Rows[0][5].Equals(DBNull.Value))
                        {
                            product.ManufacturerID = Convert.ToInt32(dt.Rows[0][5].ToString());
                        }

                    }

                    Con.Close();
                }

                return product;
            }

            /// <summary>
            /// Selecting product from Database where ID is .......
            /// </summary>
            public Product Get(int ID)
            {
                DataTable dt = null;

                Product product = new Product();

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

                        product = new Product
                        {
                            ID = Convert.ToInt32(dt.Rows[0][0].ToString()),
                            Name = dt.Rows[0][1].ToString(),
                            Description = dt.Rows[0][4].ToString(),
                            PromoDept = Convert.ToBoolean(dt.Rows[0][2]),
                            PromoFront = Convert.ToBoolean(dt.Rows[0][3]),
                            InStock = Convert.ToBoolean(dt.Rows[0][8]),
                            Category = new Categories().Get(Convert.ToInt32((dt.Rows[0][6].ToString()))),

                        };

                        if (!dt.Rows[0][5].Equals(DBNull.Value))
                        {
                            product.ManufacturerID = Convert.ToInt32(dt.Rows[0][5].ToString());
                        }
                    }

                    Con.Close();
                }

                return product;
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
            public void Edit(int CategoryID, int ProductID, string Name, string Description, int PromoFront, int PromoDept)
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

        public class Manufacturers
        {
            /// <summary>
            /// Selecting Manufacturers from Database
            /// </summary>
            public List<Manufacturer> Get()
            {
                DataTable dt = null;

                List<Manufacturer> manufacturers = new List<Manufacturer>();

                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }

                    Query = "SelectManufacturers";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        DataAdapter = new SqlDataAdapter(Com);

                        dt = new DataTable();
                        DataAdapter.Fill(dt);


                        foreach (DataRow dataRow in dt.Rows)
                        {
                            Manufacturer manufacturer = new Manufacturer
                            {
                                ID = Convert.ToInt32(dataRow[0].ToString()),
                                Name = dataRow[1].ToString(),
                                Email = dataRow[6].ToString(),
                                Logo = dataRow[2].ToString(),
                                PhoneNumber = dataRow[7].ToString(),
                                PrimaryAddress = dataRow[3].ToString(),
                                SecondaryAddress = dataRow[4].ToString(),
                                WorkNumber = dataRow[8].ToString()
                            };

                            manufacturers.Add(manufacturer);
                        }


                    }

                    Con.Close();
                }

                return manufacturers;
            }

            /// <summary>
            /// Selecting Product from Database where Name is .......
            /// </summary>
            //public DataTable Get(string Name)
            //{
            //    DataTable dt = null;

            //    using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
            //    {
            //        if (Con.State == ConnectionState.Closed)
            //        {
            //            Con.Open();
            //        }
            //        Query = "SelectProduct";

            //        using (Com = new SqlCommand(Query, Con))
            //        {
            //            Com.CommandType = CommandType.StoredProcedure;

            //            Com.Parameters.Add(new SqlParameter("@name", Name));

            //            DataAdapter = new SqlDataAdapter(Com);

            //            dt = new DataTable();
            //            DataAdapter.Fill(dt);

            //        }

            //        Con.Close();
            //    }

            //    return dt;
            //}

            /// <summary>
            /// Selecting Manufacturer from Database where ID is .......
            /// </summary>
            public Manufacturer Get(int ID)
            {
                DataTable dt = null;

                Manufacturer manufacturer = new Manufacturer();

                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    Query = "SelectManufacturer";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@ManufacturerID", ID));

                        DataAdapter = new SqlDataAdapter(Com);

                        dt = new DataTable();
                        DataAdapter.Fill(dt);

                        manufacturer = new Manufacturer
                        {
                            ID = Convert.ToInt32(dt.Rows[0][0].ToString()),
                            Name = dt.Rows[0][1].ToString(),
                            Email = dt.Rows[0][6].ToString(),
                            Logo = dt.Rows[0][2].ToString(),
                            PhoneNumber = dt.Rows[0][7].ToString(),
                            PrimaryAddress = dt.Rows[0][3].ToString(),
                            SecondaryAddress = dt.Rows[0][4].ToString(),
                            WorkNumber = dt.Rows[0][8].ToString()
                        };

                    }

                    Con.Close();
                }

                return manufacturer;
            }


            /// <summary>
            /// Adding Manufacturer to Database
            /// </summary>
            public void Add(string Name, string logo, string Email, string PhoneNumber, string PrimaryAddress, string SecondaryAddress, string WorkNumber = null)
            {
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    Query = "AddManufacturer";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@Name", Name));
                        Com.Parameters.Add(new SqlParameter("@Logo", logo));
                        Com.Parameters.Add(new SqlParameter("@Email", Email));
                        Com.Parameters.Add(new SqlParameter("@PhoneNumber", PhoneNumber));
                        Com.Parameters.Add(new SqlParameter("@WorkNumber", WorkNumber));
                        Com.Parameters.Add(new SqlParameter("@Address1", PrimaryAddress));
                        Com.Parameters.Add(new SqlParameter("@Address2", SecondaryAddress));
                        //Com.Parameters.Add(new SqlParameter("@Description", Description));

                        Com.ExecuteNonQuery();

                    }

                    Con.Close();
                }
            }

            /// <summary>
            /// Editing Manufacturer in Database
            /// </summary>
            public void Edit(int ManufacturerID, string Name, string logo, string Email, string PhoneNumber, string PrimaryAddress, string SecondaryAddress, string WorkNumber = null)
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    Query = "UpdateManufacturer";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@Name", Name));
                        Com.Parameters.Add(new SqlParameter("@Logo", logo));
                        Com.Parameters.Add(new SqlParameter("@Email", Email));
                        Com.Parameters.Add(new SqlParameter("@PhoneNumber", PhoneNumber));
                        Com.Parameters.Add(new SqlParameter("@WorkNumber", WorkNumber));
                        Com.Parameters.Add(new SqlParameter("@Address1", PrimaryAddress));
                        Com.Parameters.Add(new SqlParameter("@Address2", SecondaryAddress));

                        Com.ExecuteNonQuery();

                    }

                    Con.Close();
                }
            }

            /// <summary>
            /// Deletes Manufacturer from Database
            /// </summary>
            public void Delete(int ManufacturerID)
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    Query = "DeleteManufacturer";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@ManufacturerID", ManufacturerID));


                        Com.ExecuteNonQuery();

                    }

                    Con.Close();
                }
            }
        }

        public class Markets
        {
            /// <summary>
            /// Adds Market to the Database
            /// </summary>
            public void Add(string Name, string Description, string Address1, string Address2, string Address3 = null)
            {
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    Query = "AddMarket";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@Name", Name));
                        Com.Parameters.Add(new SqlParameter("@Description", Description));
                        Com.Parameters.Add(new SqlParameter("@Address1", Address1));
                        Com.Parameters.Add(new SqlParameter("@Address2", Address2));
                        Com.Parameters.Add(new SqlParameter("@Address2", Address3));

                        Com.ExecuteNonQuery();

                    }

                    Con.Close();
                }
            }

            /// <summary>
            /// Gets a list of markets from the Database
            /// </summary>
            public List<Market> Get()
            {
                List<Market> markets = new List<Market>();

                DataTable dt = null;

                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }

                    Query = "SelectMarkets";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        DataAdapter = new SqlDataAdapter(Com);

                        dt = new DataTable();
                        DataAdapter.Fill(dt);


                        foreach (DataRow dataRow in dt.Rows)
                        {
                            Market market = new Market()
                            {
                                ID = Convert.ToInt32(dataRow[0].ToString()),
                                Name = dataRow[1].ToString(),
                                Description = dataRow[2].ToString(),

                            };

                            Address address = new Address()
                            {
                                Address1 = dataRow[3].ToString(),
                                Address2 = dataRow[4].ToString(),
                                Address3 = dataRow[5].ToString()
                            };

                            market.Address = address;

                            markets.Add(market);
                        }

                    }

                    Con.Close();
                }
                return markets;
            }

            /// <summary>
            /// Gets market from the Database by ID
            /// </summary>
            public Market Get(int ID)
            {
                DataTable dt = null;

                Market market = new Market();

                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    Query = "SelectMarket";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@ID", ID));

                        DataAdapter = new SqlDataAdapter(Com);

                        dt = new DataTable();
                        DataAdapter.Fill(dt);

                        market = new Market()
                        {
                            ID = Convert.ToInt32(dt.Rows[0][0].ToString()),
                            Name = dt.Rows[0][1].ToString(),
                            Description = dt.Rows[0][2].ToString(),

                        };

                        Address address = new Address()
                        {
                            Address1 = dt.Rows[0][3].ToString(),
                            Address2 = dt.Rows[0][4].ToString(),
                            Address3 = dt.Rows[0][5].ToString()
                        };

                        market.Address = address;
                    }

                    Con.Close();
                }

                return market;
            }

            /// <summary>
            /// Update market information in the database
            /// </summary>
            public void Edit(int MarketID, int AddressID, string Name, string Description, string Address1, string Address2, string Address3 = null)
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    Query = "UpdateMarket";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@MarketID", MarketID));
                        Com.Parameters.Add(new SqlParameter("@AddressID", AddressID));
                        Com.Parameters.Add(new SqlParameter("@Name", Name));
                        Com.Parameters.Add(new SqlParameter("@Description", Description));
                        Com.Parameters.Add(new SqlParameter("@Address1", Address1));
                        Com.Parameters.Add(new SqlParameter("@Address2", Address2));
                        Com.Parameters.Add(new SqlParameter("@Address3", Address3));

                        Com.ExecuteNonQuery();

                        Com.Dispose();
                    }

                    Con.Close();
                }
            }

            /// <summary>
            /// Delete Market from database
            /// </summary>
            /// <param name="MarketID"></param>
            public void Delete(int MarketID)
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                using (Con = new SqlConnection(GlobalConfigurations.ConnectionString))
                {
                    Query = "DeleteMarket";

                    using (Com = new SqlCommand(Query, Con))
                    {
                        Com.CommandType = CommandType.StoredProcedure;

                        Com.Parameters.Add(new SqlParameter("@MarketID", MarketID));

                        Com.ExecuteNonQuery();

                    }

                    Con.Close();
                }
            }

        }

    }
}