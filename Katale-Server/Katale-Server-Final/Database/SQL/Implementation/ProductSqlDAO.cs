using Katale_Server_.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Katale_Server_Final.Database.SQL.Implementation
{
    public class ProductSqlDAO : SqlDAO, ISqlDAO<Product>
    {
        CategorySqlDAO CategorySqlDAO = new CategorySqlDAO();

        public void Delete(int id)
        {
            Con = this.CreateConnection();

            Query = "DeleteProduct";

            Com.Connection = Con;
            Com.CommandText = Query;

            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.Add(new SqlParameter("@id", id));

            Com.ExecuteNonQuery();

            Com.Dispose();

            Con.Close();
        }


        public bool Exists(Product model)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            DataTable dt = null;

            List<Product> products = new List<Product>();

            Con = this.CreateConnection();

            Query = "SelectProducts";

            Com.Connection = Con;
            Com.CommandText = Query;

            Com.CommandType = CommandType.StoredProcedure;

            DataAdapter.SelectCommand = Com;

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
                    Category = CategorySqlDAO.GetByID(Convert.ToInt32(dataRow[6].ToString())),

                };

                if (!dataRow[5].Equals(DBNull.Value))
                {
                    product.ManufacturerID = Convert.ToInt32(dataRow[5].ToString());
                }

                products.Add(product);

                Com.Dispose();

                Con.Close();

            }

            return products;
        }

        public Product GetByID(int id)
        {
            DataTable dt = null;

            Product product = new Product();

            Con = this.CreateConnection();

            Query = "SelectProduct";

            Com.Connection = Con;
            Com.CommandText = Query;

            Com.CommandType = CommandType.StoredProcedure;

            Com.Parameters.Clear();

            Com.Parameters.Add(new SqlParameter("@id", id));

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
                Category = CategorySqlDAO.GetByID(Convert.ToInt32((dt.Rows[0][6].ToString()))),

            };

            if (!dt.Rows[0][5].Equals(DBNull.Value))
            {
                product.ManufacturerID = Convert.ToInt32(dt.Rows[0][5].ToString());
            }

            Com.Dispose();

            Con.Close();
            return product;
        }

        public Product GetByName(string name)
        {
            DataTable dt = null;
            Product product = new Product();

            Con = this.CreateConnection();

            Query = "SelectProduct";

            Com.Connection = Con;
            Com.CommandText = Query;

            Com.CommandType = CommandType.StoredProcedure;

            Com.Parameters.Clear();

            Com.Parameters.Add(new SqlParameter("@name", name));

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
                Category = CategorySqlDAO.GetByName((dt.Rows[0][6].ToString()))

            };

            if (!dt.Rows[0][5].Equals(DBNull.Value))
            {
                product.ManufacturerID = Convert.ToInt32(dt.Rows[0][5].ToString());
            }

            Com.Dispose();

            Con.Close();

            return product;


        }

        public List<Product> GetByQuery(string Query)
        {
            throw new NotImplementedException();
        }

        public void Save(Product product)
        {
            Con = this.CreateConnection();

            Query = "AddProduct";

            Com.Connection = Con;
            Com.CommandText = Query;

            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();

            Com.Parameters.Add(new SqlParameter("@CategoryID", product.Category.ID));
            Com.Parameters.Add(new SqlParameter("@Name", product.Name));
            Com.Parameters.Add(new SqlParameter("@Description", product.Description));

            Com.ExecuteNonQuery();

            Com.Dispose();

            Con.Close();

        }

        public void Update(Product product)
        {
            Con = this.CreateConnection();

            Query = "UpdateProduct";

            Com.Connection = Con;
            Com.CommandText = Query;

            Com.CommandType = CommandType.StoredProcedure;

            Com.Parameters.Clear();

            Com.Parameters.Add(new SqlParameter("@CategoryID", product.Category.ID));
            Com.Parameters.Add(new SqlParameter("@ProductID", product.ID));
            Com.Parameters.Add(new SqlParameter("@PromoDept", product.PromoDept));
            Com.Parameters.Add(new SqlParameter("@PromoFront", product.PromoFront));
            Com.Parameters.Add(new SqlParameter("@Name", product.Name));
            Com.Parameters.Add(new SqlParameter("@Description", product.Description));

            Com.ExecuteNonQuery();

            Com.Dispose();

            Con.Close();
        }
    }
}