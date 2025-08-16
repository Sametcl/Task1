using Product_API.Models.Base;

namespace Product_API.Models
{
    public class Product:BaseModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; } = true;

    }
}
