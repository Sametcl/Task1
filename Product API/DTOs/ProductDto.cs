namespace Product_API.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; } = null!;
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
    }
}
