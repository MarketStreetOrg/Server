using Katale_Server_.Models;
using Katale_Server_Final.Models;
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
            Com.Parameters.Clear();

            DataAdapter.SelectCommand = Com;

            dt = new DataTable();
            DataAdapter.Fill(dt);


            foreach (DataRow dataRow in dt.Rows)
            {
                Address address = new Address();

                Manufacturer manufacturer = new Manufacturer
                {
                    ID = Convert.ToInt32(dataRow[0].ToString()),
                    Name = dataRow[1].ToString(),
                    Logo = dataRow[2].ToString(),
                };

                address.Email = dataRow[6].ToString();
                address.PhoneNumber = dataRow[7].ToString();
                address.Address1 = dataRow[3].ToString();
                address.Address2 = dataRow[4].ToString();
                address.WorkNumber = dataRow[8].ToString();

                manufacturer.Address = address;

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
            Com.Parameters.Clear();
            Com.Parameters.Add(new SqlParameter("@ManufacturerID", id));

            DataAdapter.SelectCommand = Com;

            dt = new DataTable();
            DataAdapter.Fill(dt);

            Address address = new Address();

            manufacturer = new Manufacturer
            {
                ID = Convert.ToInt32(dt.Rows[0][0].ToString()),
                Name = dt.Rows[0][1].ToString(),
                Logo = dt.Rows[0][2].ToString(),
            };

            address.Email = dt.Rows[0][6].ToString();
            address.PhoneNumber = dt.Rows[0][7].ToString();
            address.Address1 = dt.Rows[0][3].ToString();
            address.Address2 = dt.Rows[0][4].ToString();
            address.WorkNumber = dt.Rows[0][8].ToString();

            manufacturer.Address = address;

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

        public void Save(Manufacturer manufacturer)
        {
            Query = "AddManufacturer";

            Con = CreateConnection();
            Com.Connection = Con;
            Com.CommandText = Query;
           
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.Add(new SqlParameter("@Name", manufacturer.Name));
            Com.Parameters.Add(new SqlParameter("@Logo", manufacturer.Logo));
            Com.Parameters.Add(new SqlParameter("@Email", manufacturer.Address.Email));
            Com.Parameters.Add(new SqlParameter("@PhoneNumber", manufacturer.Address.PhoneNumber));
            Com.Parameters.Add(new SqlParameter("@WorkNumber", manufacturer.Address.WorkNumber));
            Com.Parameters.Add(new SqlParameter("@Address1", manufacturer.Address.Address1));
            Com.Parameters.Add(new SqlParameter("@Address2", manufacturer.Address.Address2));

            Com.ExecuteNonQuery();

            Con.Close();

        }

        public void Update(Manufacturer manufacturer)
        {
            Query = "UpdateManufacturer";

            Con = CreateConnection();
            Com.Connection = Con;
            Com.CommandText = Query;

            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();

            Com.Parameters.Add(new SqlParameter("@ManufacturerID", manufacturer.ID));
            Com.Parameters.Add(new SqlParameter("@Name", manufacturer.Name));
            Com.Parameters.Add(new SqlParameter("@Logo", manufacturer.Logo));
            Com.Parameters.Add(new SqlParameter("@Email", manufacturer.Address.Email));
            Com.Parameters.Add(new SqlParameter("@PhoneNumber", manufacturer.Address.PhoneNumber));
            Com.Parameters.Add(new SqlParameter("@WorkNumber", manufacturer.Address.WorkNumber));
            Com.Parameters.Add(new SqlParameter("@AddressID", manufacturer.Address.ID));
            Com.Parameters.Add(new SqlParameter("@Address1", manufacturer.Address.Address1));
            Com.Parameters.Add(new SqlParameter("@Address2", manufacturer.Address.Address2));

            Com.ExecuteNonQuery();

            Con.Close();
        }
    }
}