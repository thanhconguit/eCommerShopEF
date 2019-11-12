using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceShop.Data.Models
{
    public class User

    {
        public int Id { get; set; }
        public string FullName { get; set; }
      
        public string Password { get; set; }
       
        public string Email { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public IList<Product> Products { get; set; }
        public virtual  Role Role { get; set; }
    }
}
