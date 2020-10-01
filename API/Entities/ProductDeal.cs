using System;

namespace SupermarketCheckout
{
    public class ProductDeal
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }
        public ProductItem ProductItem { get; set; }
        public int ProductItemId { get; set; }
    }
}