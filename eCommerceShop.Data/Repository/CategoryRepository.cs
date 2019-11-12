using eCommerceShop.Data.Context;
using eCommerceShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Data.Repository
{
    public class CategoryRepository : ICategoryRepository

    {
        private readonly eCommerceShopDbContext _dbContext;
        public CategoryRepository(eCommerceShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _dbContext.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateAsync(Category category)
        {
            await _dbContext.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateAsync(Category category)
        {
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var caterory = await FindByIdAsync(id);
            if (caterory != null)
            {
                 _dbContext.Categories.Remove(caterory);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
