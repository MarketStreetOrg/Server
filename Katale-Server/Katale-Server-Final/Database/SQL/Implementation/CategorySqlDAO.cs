using Katale_Server_.Database;
using Katale_Server_.Models;
using Katale_Server_Final.Service;
using Katale_Server_Final.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Database.SQL
{
    public class CategorySqlDAO : SqlDAO, ISqlDAO<Category>
    {
        
        DepartmentSqlDAO departmentSqlDao=new DepartmentSqlDAO();

        public void Delete(int id)
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

                    Com.Parameters.Add(new SqlParameter("@id", id));


                    Com.ExecuteNonQuery();

                }

                Con.Close();
            }
        }

        public bool Exists(Category model)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
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
                            Department = departmentSqlDao.GetByID(Convert.ToInt32(dataRow[3].ToString())),
                            Products = Convert.ToInt32(dataRow[5])
                        };

                        categories.Add(category);
                    }

                }

                Con.Close();

            }

            return categories;
        }

        public Category GetByID(int id)
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

                    Com.Parameters.Add(new SqlParameter("@id", id));

                    DataAdapter = new SqlDataAdapter(Com);

                    dt = new DataTable();
                    DataAdapter.Fill(dt);

                    category = new Category
                    {
                        ID = Convert.ToInt32(dt.Rows[0][0].ToString()),
                        Name = dt.Rows[0][1].ToString(),
                        Description = dt.Rows[0][2].ToString(),
                        Department = departmentSqlDao.GetByID(Convert.ToInt32(dt.Rows[0][3].ToString())),
                        Products = Convert.ToInt32(dt.Rows[0][5])

                    };

                }

                Con.Close();
            }

            return category;
        }

        public Category GetByName(string name)
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

                    Com.Parameters.Add(new SqlParameter("@name", name));

                    DataAdapter = new SqlDataAdapter(Com);

                    dt = new DataTable();
                    DataAdapter.Fill(dt);

                    category = new Category
                    {
                        ID = Convert.ToInt32(dt.Rows[0][0].ToString()),
                        Name = dt.Rows[0][1].ToString(),
                        Description = dt.Rows[0][2].ToString(),
                        Department = departmentSqlDao.GetByID(Convert.ToInt32(dt.Rows[0][3].ToString())),
                        Products = Convert.ToInt32(dt.Rows[0][5])

                    };

                }

                Con.Close();
            }

            return category;
        }

        public List<Category> GetByQuery(string Query)
        {
            throw new NotImplementedException();
        }

        public void Save(Category category)
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

                    Com.Parameters.Add(new SqlParameter("@Departmentid", category.Department.ID));
                    Com.Parameters.Add(new SqlParameter("@Name", category.Name));
                    Com.Parameters.Add(new SqlParameter("@Description", category.Description));

                    Com.ExecuteNonQuery();

                }

                Con.Close();
            }
        }

        public void Update(Category category)
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

                    Com.Parameters.Add(new SqlParameter("@CategoryID", category.ID));
                    Com.Parameters.Add(new SqlParameter("@DepartmentID", category.Department.ID));
                    Com.Parameters.Add(new SqlParameter("@Name", category.Name));
                    Com.Parameters.Add(new SqlParameter("@Description", category.Description));

                    Com.ExecuteNonQuery();

                }

                Con.Close();
            }
        }
    }
}