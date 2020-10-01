using System;
using System.Collections.Generic;

namespace SupermarketCheckout
{
    public class ProductItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public ICollection<ProductDeal> ProductDeals { get; set; }

    }
}