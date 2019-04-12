using Katale_Server_Final.Database;
using MongoDB.Bson.Serialization.Attributes;

namespace Katale_Server_.Models
{
    public class Product
    {
        [BsonElement("_id"),BsonId]
        public int ID { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement]
        public string Description { get; set; }

        [BsonElement]
        public bool PromoDept { get; set; }

        [BsonElement]
        public bool PromoFront { get; set; }

        [BsonElement]
        public bool InStock { get; set; }

        [BsonElement]
        public Category Category { get; set; }

        [BsonElement]
        public int ManufacturerID { get; set; }

        Engine.Categories categories = new Engine.Categories();
        Engine.Manufacturers Manufacturers = new Engine.Manufacturers();
        ///<summary>
        ///Gets the manufacturer of this product
        /// </summary>
        public Manufacturer GetManufacturer()
        {
            return Manufacturers.Get(ManufacturerID);

        }

        ///<summary>
        ///Gets the Category in which this product falls
        /// </summary>
        //public Category GetCategory()
        //{
        //    return categories.Get(CategoryID);
        //}

        public class Builder
        {
            private Product product = new Product();

            public Builder SetName(string Name)
            {
                product.Name = Name;

                return this;
            }

            public Builder SetDescription(string Description)
            {
                product.Description = Description;

                return this;
            }

            public Builder IsPromoDepartment(bool boolean)
            {
                product.PromoDept = boolean;

                return this;
            }

            public Builder IsPromoFront(bool boolean)
            {
                product.PromoFront = boolean;

                return this;
            }

            public Builder IsInStock(bool boolean)
            {
                product.InStock = boolean;

                return this;
            }

            public Builder SetCategory(Category category)
            {
                product.Category = category;

                return this;
            }

            public Product Build()
            {
                return product;
            }
        }

    }
    
}