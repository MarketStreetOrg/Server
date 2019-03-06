using Katale_Server_.Database;
using Katale_Server_.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Database.SQL
{
    public class DepartmentSqlDAO : SqlDAO , ISqlDAO<Department>
    {

        public void Delete(int id)
        {
            this.CreateConnection();

            Query = "DeleteDepartment";

            using (Com = new SqlCommand(Query, Con))
            {
                Com.CommandType = CommandType.StoredProcedure;

                Com.Parameters.Add(new SqlParameter("@id", id));


                Com.ExecuteNonQuery();

                Con.Close();
            }
        }

        public bool Exists(Department model)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            List<Department> departments = new List<Department>();

            DataTable dt = null;

            Con=this.CreateConnection();
            
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

                

                Con.Close();
            }

            return departments;
        }

        public Department GetByID(int id)
        {
            Department department = new Department();

            DataTable dt = null;

            this.CreateConnection();

            Query = "SelectDepartment";

            using (Com = new SqlCommand(Query, Con))
            {
                Com.CommandType = CommandType.StoredProcedure;

                Com.Parameters.Add(new SqlParameter("@id", id));

                DataAdapter = new SqlDataAdapter(Com);

                dt = new DataTable();
                DataAdapter.Fill(dt);

                department.ID = Convert.ToInt32(dt.Rows[0][0].ToString());
                department.Name = dt.Rows[0][1].ToString();
                department.Description = dt.Rows[0][2].ToString();

            }

            Con.Close();


            return department;
        }

        public Department GetByName(string name)
        {
            Department department = new Department();

            DataTable dt = null;

            this.CreateConnection();

            Query = "SelectDepartment";

            using (Com = new SqlCommand(Query, Con))
            {
                Com.CommandType = CommandType.StoredProcedure;

                Com.Parameters.Add(new SqlParameter("@name", name));

                DataAdapter = new SqlDataAdapter(Com);

                dt = new DataTable();
                DataAdapter.Fill(dt);

                department.ID = Convert.ToInt32(dt.Rows[0][0].ToString());
                department.Name = dt.Rows[0][1].ToString();
                department.Description = dt.Rows[0][2].ToString();

            }

            Con.Close();


            return department;
        }

        public List<Department> GetByQuery(string Query)
        {
            throw new NotImplementedException();
        }

        public void Save(Department model)
        {
            this.CreateConnection();

            Query = "AddDepartment";

            using (Com = new SqlCommand(Query, Con))
            {
                Com.CommandType = CommandType.StoredProcedure;

                Com.Parameters.Add(new SqlParameter("@Name", model.Name));
                Com.Parameters.Add(new SqlParameter("@Description", model.Description));

                Com.ExecuteNonQuery();

            }

            Con.Close();
        }

        public void Update(Department department)
        {

            this.CreateConnection();

            Query = "UpdateDepartment";

            using (Com = new SqlCommand(Query, Con))
            {
                Com.CommandType = CommandType.StoredProcedure;

                Com.Parameters.Add(new SqlParameter("@DepartmentID", department.ID));
                Com.Parameters.Add(new SqlParameter("@Name", department.Name));
                Com.Parameters.Add(new SqlParameter("@Description", department.Description));

                Com.ExecuteNonQuery();

            }

            Con.Close();
        }
    }
}