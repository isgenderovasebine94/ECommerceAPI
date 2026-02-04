namespace EcommerceAPI.Entities
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
