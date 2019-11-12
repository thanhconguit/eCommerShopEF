using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceShop.Data.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public  Product Product { get; set; }
        public  Order Order { get; set; }

    }
}
