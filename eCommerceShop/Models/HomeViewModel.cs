using eCommerceShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceShop.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Category> categoriesList { get; set; }
        public IEnumerable<Product> productsList { get; set; }
    }
}
