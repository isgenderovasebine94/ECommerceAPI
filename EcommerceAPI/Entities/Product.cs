using System.Collections.Generic;

namespace EcommerceAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public decimal Price { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        // Navigation Property
        public Category Category { get; set; }
    }
}