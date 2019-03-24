using Katale_Server_Final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Database.SQL.Implementation
{
    public class MarketSqlDAO : SqlDAO, ISqlDAO<Market>
    {
        public void Delete(int id)
        {

            Query = "DeleteMarket";

            Con = CreateConnection();
            Com.Connection = Con;
            Com.CommandText = Query;

            Com.CommandType = CommandType.StoredProcedure;

            Com.Parameters.Clear();

            Com.Parameters.Add(new SqlParameter("@MarketID", id));

            Com.ExecuteNonQuery();

            Con.Close();

        }

        public bool Exists(Market model)
        {
            throw new NotImplementedException();
        }

        public List<Market> GetAll()
        {
            List<Market> markets = new List<Market>();

            DataTable dt = null;

            Query = "SelectMarkets";

            Con = CreateConnection();
            Com.Connection = Con;
            Com.CommandText = Query;

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
                    ID = Convert.ToInt32(dataRow[6].ToString()),
                    Address1 = dataRow[3].ToString(),
                    Address2 = dataRow[4].ToString(),
                    Address3 = dataRow[5].ToString()
                };

                market.Address = address;

                markets.Add(market);
            }

            Con.Close();

            return markets;
        }

        public Market GetByID(int id)
        {
            DataTable dt = null;

            Market market = new Market();

            Query = "SelectMarket";

            Con = CreateConnection();
            Com.Connection = Con;
            Com.CommandText = Query;

            Com.CommandType = CommandType.StoredProcedure;

            Com.Parameters.Clear();

            Com.Parameters.Add(new SqlParameter("@ID", id));

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
                ID = Convert.ToInt32(dt.Rows[0][6].ToString()),
                Address1 = dt.Rows[0][3].ToString(),
                Address2 = dt.Rows[0][4].ToString(),
                Address3 = dt.Rows[0][5].ToString()
            };

            market.Address = address;

            Con.Close();

            Com.Dispose();

            return market;
        }

        public Market GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Market> GetByQuery(string Query)
        {
            throw new NotImplementedException();
        }

        public void Save(Market market)
        {

            Query = "AddMarket";

            Con = CreateConnection();
            Com.Connection = Con;
            Com.CommandText = Query;

            Com.CommandType = CommandType.StoredProcedure;

            Com.Parameters.Clear();

            Com.Parameters.Add(new SqlParameter("@Name", market.Name));
            Com.Parameters.Add(new SqlParameter("@Description", market.Description));
            Com.Parameters.Add(new SqlParameter("@Address1", market.Address.Address1));
            Com.Parameters.Add(new SqlParameter("@Address2", market.Address.Address2));
            Com.Parameters.Add(new SqlParameter("@Address3", market.Address.Address3));

            Com.ExecuteNonQuery();

            Com.Dispose();

            Con.Close();

        }

        public void Update(Market market)
        {

            Query = "UpdateMarket";

            Con = CreateConnection();
            Com.Connection = Con;
            Com.CommandText = Query;

            Com.CommandType = CommandType.StoredProcedure;

            Com.Parameters.Clear();

            Com.Parameters.Add(new SqlParameter("@Name", market.Name));
            Com.Parameters.Add(new SqlParameter("@Description", market.Description));
            Com.Parameters.Add(new SqlParameter("@Address1", market.Address.Address1));
            Com.Parameters.Add(new SqlParameter("@Address2", market.Address.Address2));
            Com.Parameters.Add(new SqlParameter("@Address3", market.Address.Address3));
            Com.Parameters.Add(new SqlParameter("@MarketID", market.ID));
            Com.Parameters.Add(new SqlParameter("@AddressID", market.Address.ID));


            Com.ExecuteNonQuery();

            Com.Dispose();

            Con.Close();

        }
    }
}