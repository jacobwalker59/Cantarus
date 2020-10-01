namespace SupermarketInterfaces
{
    public interface ICheckout
    {
        /// <summary>s
        /// Configure the ICheckout instance to use the passed pricings.
        /// </summary>
        /// <param name="pricings"></param>
        void Configure(IPricings pricings);

        /// <summary>
        /// Add an item with the passed SKU.
        /// </summary>
        /// <param name="sku"></param>
        void Scan(string sku);

        /// <summary>
        /// Remove an item with the passed SKU.
        /// </summary>
        /// <param name="sku"></param>
        void Remove(string sku);

        /// <summary>
        /// Remova all items.
        /// </summary>
        void Empty();

        /// <summary>
        /// Value of all items in basket, this excludes any discounts or offers.
        /// <returns></returns>
        float Subtotal();

        /// <summary>
        /// Amount that the customer has saved from discounts and offers.
        /// </summary>
        /// <returns></returns>
        float Savings();

        /// <summary>
        /// Total amount the customer needs to pay.
        /// </summary>
        /// <returns></returns>
        float Total();
    }
}
