namespace EcommerceAPI.Entities.Dtos.Products
{
    public class GetProductDto
    {
       
        public string Name { get; set; }

        public string Desc { get; set; }

        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
