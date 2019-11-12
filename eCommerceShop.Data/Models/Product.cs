﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceShop.Data.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public User Sell { get; set; }
        public virtual Category Category { get; set; }


    }
}
