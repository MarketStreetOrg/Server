using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Katale_Server_.Models;
using Katale_Server_Final.Database;
using Katale_Server_Final.Database.SQL.Implementation;

namespace Katale_Server_Final.Service.Implementation
{
    public class ProductService : IProductService
    {
        IGenericDAO<Product> ProductDAO { get; set; }

        public ProductService(IGenericDAO<Product> DataAccessObject)
        {
            this.ProductDAO = DataAccessObject;
        }

        public ProductService()
        {
            this.ProductDAO = new ProductSqlDAO();
        }


        public void Delete(int id)
        {
            ProductDAO.Delete(id);
        }

        public List<Product> GetAll()
        {
            return ProductDAO.GetAll();
        }

        public Product GetSingle(int id)
        {
            return ProductDAO.GetByID(id);
        }

        public Product GetSingle(string Name)
        {
            return ProductDAO.GetByName(Name);
        }

        public Product GetSingle(Product product)
        {
            throw new NotImplementedException();
        }

        public void Save(Product product)
        {
            ProductDAO.Save(product);
        }

        public Product Update(Product product)
        {
            ProductDAO.Update(product);

            return ProductDAO.GetByID(product.ID);
        }

        public bool Exists(Product product)
        {
            return ProductDAO.Exists(product);
        }
    }
}