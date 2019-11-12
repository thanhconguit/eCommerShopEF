using eCommerceShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Data.Repository
{
    public interface IRoleRepository
    {
        Task<bool> CreateAsync(Role role);
        Task<bool> DeleteAsync(string id);
        Task<Role> FinByIdAsync(int roleId);
        Task<IEnumerable<Role>> GetAll();
    }
}
