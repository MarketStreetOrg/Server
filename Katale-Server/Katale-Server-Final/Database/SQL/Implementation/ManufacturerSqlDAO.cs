using Katale_Server_.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Database.SQL.Implementation
{
    public class ManufacturerSqlDAO : SqlDAO, ISqlDAO<Manufacturer>
    {
        public void Delete(int id)
        {
            Query = "DeleteManufacturer";

            Con = CreateConnection();
            Com.Connection = Con;
            Com.CommandText = Query;

            Com.CommandType = CommandType.StoredProcedure;

            Com.Parameters.Add(new SqlParameter("@ManufacturerID", id));

            Com.ExecuteNonQuery();
        }

        public bool Exists(Manufacturer model)
        {
            throw new NotImplementedException();
        }

        public List<Manufacturer> GetAll()
        {
            DataTable dt = null;

            List<Manufacturer> manufacturers = new List<Manufacturer>();

            Query = "SelectManufacturers";

            Con = CreateConnection();
            Com.Connection = Con;
            Com.CommandText = Query;

            Com.CommandType = CommandType.StoredProcedure;

            DataAdapter.SelectCommand = Com;

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

                Con.Close();
            }

            return manufacturers;
        }

        public Manufacturer GetByID(int id)
        {
            DataTable dt = null;

            Manufacturer manufacturer = new Manufacturer();

            Query = "SelectManufacturer";

            Con = CreateConnection();
            Com.Connection = Con;
            Com.CommandText = Query;


            Com.CommandType = CommandType.StoredProcedure;

            Com.Parameters.Add(new SqlParameter("@ManufacturerID", id));

            DataAdapter.SelectCommand = Com;

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

            return manufacturer;
        }

        public Manufacturer GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Manufacturer> GetByQuery(string Query)
        {
            throw new NotImplementedException();
        }

        public void Save(Manufacturer model)
        {
            Con = CreateConnection();
            Com.Connection = Con;
            Com.CommandText = Query;
        }

        public void Update(Manufacturer manufacturer)
        {
            Query = "UpdateManufacturer";

            Con = CreateConnection();
            Com.Connection = Con;
            Com.CommandText = Query;

            Com.CommandType = CommandType.StoredProcedure;

            Com.Parameters.Add(new SqlParameter("@Name", manufacturer.Name));
            Com.Parameters.Add(new SqlParameter("@Logo", manufacturer.Logo));
            Com.Parameters.Add(new SqlParameter("@Email", manufacturer.Email));
            Com.Parameters.Add(new SqlParameter("@PhoneNumber", manufacturer.PhoneNumber));
            Com.Parameters.Add(new SqlParameter("@WorkNumber", manufacturer.WorkNumber));
            Com.Parameters.Add(new SqlParameter("@Address1", manufacturer.PrimaryAddress));
            Com.Parameters.Add(new SqlParameter("@Address2", manufacturer.SecondaryAddress));

            Com.ExecuteNonQuery();

            Con.Close();
        }
    }
}