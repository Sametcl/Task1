using Product_API.DTOs.Product;
using Product_API.Models;
using Product_API.Repositories.Abstractions;
using Product_API.Repositories.Concretes;
using Product_API.Services.Abstractions;

namespace Product_API.Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
            var productList = await productRepository.GetAllAsync();
            return productList.Select(p => new ProductDto { Id = p.Id, Name = p.Name, Price = p.Price });

        }
        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return null;
            }
            return new ProductDto { Id = product.Id, Name = product.Name, Price = product.Price };
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price
            };

        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return false;
            }
            await productRepository.DeleteAsync(id);
            return true;
        }

        public async Task<ProductDto> UpdateProductAsync(UpdateProductDto updateProductDto,Guid id)
        {
           
            var existingProduct = await productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return null;
            }

           
            existingProduct.Name = updateProductDto.Name;
            existingProduct.Description = updateProductDto.Description;
            existingProduct.Price = updateProductDto.Price;

            await productRepository.UpdateAsync(existingProduct);
 
            return new ProductDto
            {
                Id = existingProduct.Id,
                Name = existingProduct.Name,
                Price = existingProduct.Price
            };
        }
    }
}
