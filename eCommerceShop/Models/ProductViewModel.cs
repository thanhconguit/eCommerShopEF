using eCommerceShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceShop.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Category> categoriesList { get; set; }
        public Product product { get; set; }
    }
}
