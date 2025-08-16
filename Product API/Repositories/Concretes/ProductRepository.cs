
using Microsoft.EntityFrameworkCore;
using Product_API.Context;
using Product_API.DTOs;
using Product_API.Models;
using Product_API.Repositories.Abstractions;

namespace Product_API.Repositories.Concretes
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task AddAsync(Product product)
        {
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Product? product = await dbContext.Products.FindAsync(id);
            if (product != null)
            {
                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await dbContext.Products.FindAsync(id);

        }
        public async Task UpdateAsync(Product product)
        {
            //Bir modelin tum kisimlarini update edecegimiz icin bu metodu kullandim .
            //Ancak belirli bir kismi ornegin(Name ve description)
            //degisecekse bunun icin repository yazmamiza gerek yok service kisminda halledilebilir.
            dbContext.Products.Update(product); 
            await dbContext.SaveChangesAsync();
        }
    }
}
