﻿using eCommerceShop.Data.Context;
using eCommerceShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Data.Repository
{
    public  class RoleRepository : IRoleRepository
    {
        private readonly eCommerceShopDbContext _dbContext;
        public RoleRepository(eCommerceShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateAsync(Role role)
        {
            _dbContext.Add(role);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if(role != null)
            {
                _dbContext.Roles.Remove(role);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            return false;
        }
        public async Task<Role> FinByIdAsync(int roleId)
        {
            return await _dbContext.Roles.FindAsync(roleId);
        }
        public async Task<IEnumerable<Role>> GetAll()
        {
            return _dbContext.Roles;
        }
    }
}
