using Katale_Server_.Models;
using Katale_Server_Final.Service;
using Katale_Server_Final.Service.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Katale_Server_.Database.Engine.Tests
{
    [TestClass()]
    public class CategoriesTests
    {
        ICategoryService categoryService = new CategoryService();
        IDepartmentService departmentService = new DepartmentService();

        [TestMethod()]
        public void EditTest()
        {
        }

        [TestMethod()]
        public void ListAllCategories()
        {
            Assert.IsNotNull(categoryService.GetAll());
        }

        [TestMethod()]
        public void TestGetSingleCategory()
        {
            Assert.IsNotNull(categoryService.GetSingle(1));
        }

        [TestMethod()]
        public void TestAddCategory()
        {
            Category category = new Category.Builder()
                                            .SetName("test Category")
                                            .SetDescription("My Test categroy")
                                            .SetDepartment(departmentService.GetSingle(1))
                                            .Build();

            categoryService.Save(category);
           
        }
    }
}