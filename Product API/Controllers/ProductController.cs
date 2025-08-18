using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_API.DTOs.Product;
using Product_API.Services.Abstractions;
using Product_API.Services.Concretes;

namespace Product_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var productList = await productService.GetAllProductAsync();
            return Ok(productList);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Urun bulunamadi");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (createProductDto.Price < 0)
            {
                return BadRequest("Fiyat 0 dan buyuk bir deger olmalidir ");
            }
            await productService.CreateProductAsync(createProductDto);
            return Ok("Urun basarili bir sekilde eklenmistir");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await productService.DeleteProductAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Guid id, UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedProduct = await productService.UpdateProductAsync(updateProductDto, id);

            if (updatedProduct == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
