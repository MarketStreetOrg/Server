using Katale_Server_.Models;
using Katale_Server_Final.Database;
using Katale_Server_Final.Side_Code;
using Katale_Server_Final.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;


namespace Katale_Server_Final.Test
{
    [TestClass()]
    public class DomainTest
    {

        [TestMethod()]
        public void TestAttribute()
        {
            System.Reflection.MemberInfo memberInfo = typeof(Department);

            //SqlDAO<Department> sqlDAO = new SqlDAO<Department>();
            //SqlDAO<Category> sqlDAO2 = new SqlDAO<Category>();

            //List<Department> categories = sqlDAO.GetAll();

            System.Diagnostics.Debug.Write(" ");

        }

     
    }
}