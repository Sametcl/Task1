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
            return productList.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CreatedDate = p.CreatedDate,
                Status = p.Status,
                UpdatedDate =p.UpdateDate
            });

        }
        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return null;
            }
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CreatedDate = product.CreatedDate,
                Status = product.Status
            };
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price
            };
            await productRepository.CreateAsync(product);

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

        public async Task<ProductDto> UpdateProductAsync(UpdateProductDto updateProductDto, Guid id)
        {

            var existingProduct = await productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Name = updateProductDto.Name;
            existingProduct.Description = updateProductDto.Description;
            existingProduct.Price = updateProductDto.Price;
            existingProduct.CreatedDate=existingProduct.CreatedDate;
            existingProduct.Status = updateProductDto.Status;
            existingProduct.UpdateDate = DateTime.UtcNow;

            await productRepository.UpdateAsync(existingProduct);

            return new ProductDto
            {
                Id = existingProduct.Id,
                Name = existingProduct.Name,
                Price = existingProduct.Price,
                CreatedDate =existingProduct.CreatedDate,
                UpdatedDate =existingProduct.UpdateDate,
            };
        }


    }
}
