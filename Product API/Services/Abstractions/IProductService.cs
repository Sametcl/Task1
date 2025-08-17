using Product_API.DTOs.Product;

namespace Product_API.Services.Abstractions
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task<bool> DeleteProductAsync(Guid id);
        Task<ProductDto> UpdateProductAsync(UpdateProductDto updateProductDto,Guid id);

    }
}
