using System.Runtime.InteropServices.ComTypes;
using System.Linq;
using SupermarketCheckout;
using SupermarketInterfaces;

namespace API.Services
{
    public class Pricing : IPricings
    {
        private readonly DatabaseContext _db;
        public Pricing(DatabaseContext db)
        {
            _db = db;

        }
        public void AddDeal(string sku, int count, float price)
        {
           var productItem = _db.ProductItems.Where(x => x.ProductName.Contains(sku)).FirstOrDefault();
           if(productItem.ProductName == null)
           {
                throw new System.NotImplementedException("Item does not exist for deal to be applied to");
           }
           ProductDeal productDeal = new ProductDeal{Count = count, Price = price};
           productItem.ProductDeals.Add(productDeal);
           _db.SaveChanges();
        }

        public void AddProduct(string sku, float price)
        {
            var checkProductItemExists = _db.ProductItems.Where(x => x.ProductName.Contains(sku)).FirstOrDefault();
            if(checkProductItemExists.ProductName.ToLower().Equals(sku.ToLower()))
            {
                throw new System.NotImplementedException("Product Has Same Sku With Differnt Case Only, Please Create Another Sku");
            }
            // check if products only differ by case
            if(checkProductItemExists != null)
            {
                throw new System.NotImplementedException("Product Already Exists Please Use Another Sku");
            }
            var newProductItem = new ProductItem{ProductName=sku, ProductPrice=price};
            _db.ProductItems.Add(newProductItem);
           _db.SaveChanges();
        }


    }
}