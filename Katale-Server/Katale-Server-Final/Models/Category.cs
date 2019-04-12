using Katale_Server_Final.Database;
using Katale_Server_Final.Utilities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Katale_Server_.Models
{
    [Entity("categories")]
    public class Category
    {
        Engine.Departments departments = new Engine.Departments();

        [BsonElement("_id"), BsonId]
        public int ID { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("_department")]
        public Department Department { get; set; }
        /// <summary>
        /// Returns the number of products within this category
        /// </summary>
        /// 
        
        [BsonElement]
        public List<Product> Products { get; set; }

        [BsonElement("productCount")]
        [Transient]
        public int ProductCount { get; set; }

        public Category()
        {


        }


        /////<summary>
        /////Get Department where this category stands
        ///// </summary>
        //public Department GetDepartment()
        //{
        //    return departments.Get(DepartmentID);
        //}

        public class Builder
        {
            private Category category = new Category();

            public Builder SetName(string Name)
            {
                category.Name = Name;

                return this;
            }

            public Builder SetDescription(string Description)
            {
                category.Description = Description;

                return this;
            }

            public Builder SetDepartment(Department department)
            {
                category.Department = department;

                return this;
            }

            public Category Build()
            {
                return category;
            }
        }

    }
}