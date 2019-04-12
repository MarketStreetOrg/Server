using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Katale_Server_.Models;
using Katale_Server_Final.Database;
using Katale_Server_Final.Database.SQL;

namespace Katale_Server_Final.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        IGenericDAO<Category> CategoryDAO { get; set; }

        public CategoryService(IGenericDAO<Category> DataAccessObject)
        {
            this.CategoryDAO = DataAccessObject;
        }

        public CategoryService()
        {
            this.CategoryDAO = new CategorySqlDAO();
        }

        public void Delete(int id)
        {
            CategoryDAO.Delete(id);
        }

        public List<Category> GetAll()
        {
            return CategoryDAO.GetAll();
        }

        public Category GetSingle(int id)
        {
            return CategoryDAO.GetByID(id);
        }

        public Category GetSingle(string Name)
        {
            return CategoryDAO.GetByName(Name);
        }

        public Category GetSingle(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Category category)
        {
            CategoryDAO.Save(category);
        }

        public Category Update(Category category)
        {
            CategoryDAO.Update(category);

            return CategoryDAO.GetByID(category.ID);
        }

        public bool Exists(Category category)
        {
            return CategoryDAO.Exists(category);
        }
    }

}
