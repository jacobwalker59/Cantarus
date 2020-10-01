namespace SupermarketInterfaces
{
    public interface IPricings
    {
        /// <summary>
        /// Add a new product to the pricings.
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="price"></param>
        void AddProduct(string sku, float price);

        /// <summary>
        /// Add a new deal to the pricings.
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="count"></param>
        /// <param name="price"></param>
        void AddDeal(string sku, int count, float price);
    }
}
