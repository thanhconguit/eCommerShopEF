using eCommerceShop.Data.Context;
using eCommerceShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly eCommerceShopDbContext _dbContext;
        public ProductRepository(eCommerceShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
         
        public async Task<bool> CreateAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return true;
           
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await FindByIdAsync(id);
            if(product !=null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
       

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _dbContext.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();

        }
        public async Task<Category> GetByCategoryIdAsync(int categoryId)
        {
            return await _dbContext.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == categoryId);
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
