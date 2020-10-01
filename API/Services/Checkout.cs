using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupermarketCheckout;
using SupermarketInterfaces;

/*
-------------------Logic For The Application------------------------

The assumption that items have deals assigned to them
Each item can have more than one deal
For example, apples could have the following deals...

- Buy __1__ apple for __£1.00__
- Buy __3__ apples for __£2.00__
- Buy __7__ apples for __£4.20__

The cart is represented by the Dictionary, which holds Items as the key and the quantity of Items as the value

If there are no apples in the dictionary, the apples are added into the dictionary, the apples object holds 
all deals of apples as an array, represented by one to many in entity framework

If apples do exist, their value is incremented by one, dictionary used same way as a set so  no duplicates can be used

-------------Logic for Calculation of Subtotal (The one where deals are applied to total price)-----------------

1) Iterate through every item in the list
2) If the items have any deals then use them, otherwise calculate the price of the items by multiplying the keys
product price by its value and adding it to total count
3) Get the highest deal so for example, there are 15 apples in the basket, the largest deal applies to 7 apples
so use this deal, once this deal has been calculated, remove the deal from the items deal list, then check if 
you can use the next highest one, this only works if there is not two sets or more of the highest deal
so there are 15 apples, the deal applies to 7 apples, 15-7 =8. 8 is greater than 7 so the deal is applied again
8-7 = 1 deal is added to calculation , there are no deals for 1 remaining apple, so price is checked normally.
Needed to check the minimum number of apples in the cart to constitute a deal. 
So if there are 4 apples in the cart, smallest deal is 3, go back through the loop and try it again
end the loop

Would have tested via postman or standard testing procedures but due to personal time constraints had to complete quickly

Other methods check whether or not the product exists, if product is null create a null exception
again would have created own exception handler for company and created own exceptions, but throwing a new exception was
best under the cirumstances. 

*/

namespace API.Services
{
    public class Checkout : ICheckout
    {
        public Dictionary<ProductItem, int> productItems = new Dictionary<ProductItem, int>();

        // likely going to need a list of the product item deals... and then a corresponding
        // number for how many of each item there are
        // use recursion to reduce number of item, associated with each product. 
        private readonly DatabaseContext _db;
        public Checkout(DatabaseContext db)
        {
            _db = db;
            // create a temporary list of items here at least that takes care of remove items. 
            // will need to check the body in query
            // configure can set the items together. 
        }

        public int returnHighestDealsPerItem(ICollection<ProductDeal> dealListPerItem)
        {
          int highestItemDealCount = 0;
            foreach(var dealItem in dealListPerItem)
                    {
                        if(dealItem.Count > highestItemDealCount)
                        {
                            highestItemDealCount = dealItem.Count;
                        }
                    }
                    return highestItemDealCount;
        }

        public int returnLowestDealsPerItem(ICollection<ProductDeal> dealListPerItem)
        {
          int highestItemDealCount = 0;
            foreach(var dealItem in dealListPerItem)
                    {
                        if(highestItemDealCount == 0)
                        {
                            highestItemDealCount = dealItem.Count;
                        }
                        else if(dealItem.Count < highestItemDealCount)
                        {
                            highestItemDealCount = dealItem.Count;
                        }
                    }
                    return highestItemDealCount;
        }


         public float Subtotal()
        {
            // first need a list of all product deals that correspond to each item in the product list
            List<ProductDeal> deals = new List<ProductDeal>();
            float totalCount = 0;
            
            foreach(var item in productItems)
            {
                int countOfObjectsPerItem = item.Value;
                if(item.Key.ProductDeals.Count>0)
                {
                    var dealListPerItem = item.Key.ProductDeals;
                   
                    int highestItemDealCount = returnHighestDealsPerItem(dealListPerItem);

                    while(dealListPerItem.Count>0)
                    {
                        if(countOfObjectsPerItem > highestItemDealCount)
                        {
                            var highestItem = dealListPerItem.Where(x => x.Count == highestItemDealCount).FirstOrDefault();
                            totalCount += highestItem.Price;
                            productItems[item.Key]-=highestItem.Count;
                            countOfObjectsPerItem = countOfObjectsPerItem - highestItemDealCount;
                        }
                        // get minimum deal 
                        else if(countOfObjectsPerItem > 0 && countOfObjectsPerItem <= returnLowestDealsPerItem(dealListPerItem)) {
                            var highestItem = dealListPerItem.Where(x => x.Count == highestItemDealCount).FirstOrDefault();
                            dealListPerItem.Remove(highestItem);
                            highestItemDealCount = returnLowestDealsPerItem(dealListPerItem);
                        }
                        // 
                    }
                }

                else{
                    totalCount += (item.Key.ProductPrice * item.Value);
                }
            }
            
            return totalCount;
           
        }

        public float Total()
        {
            float count = 0;
            foreach(var item in productItems)
            {
                count += (item.Key.ProductPrice * item.Value);
            }
            // takes the price of each item and multiplies it by how much item number 

            return count;
        }

        public async Task<List<ProductItem>> getAllItems()
        {
            return await _db.ProductItems.ToListAsync();
        }

        public void Configure(IPricings pricings)
        {
            //?? not sure what this bit was asking for, but used the remaining code to find a work around
            throw new System.NotImplementedException();
        }

        public void Empty()
        {
            productItems.Clear();
        }

        public void Remove(string sku)
        {
            if(productItems.Count !>0)
            {
                 throw new System.NotImplementedException("No items present that can be removed");
            }
            var itemToRemove = productItems.Where(x => x.Key.ProductName == sku).FirstOrDefault();
            if(itemToRemove.Key == null)
            {
                 throw new System.NotImplementedException("Item does not exist for removal, please check again");
            }

            var item = itemToRemove.Key;
            productItems.Remove(item);
        }

        public float Savings()
        {   
           return Total() - Subtotal();
        }

        public void Scan(string sku)
        {   
            // this is wrong needs to be taken from the db
            var item = _db.ProductItems.Where(x => x.ProductName == sku).FirstOrDefault();
            // need to add an exception if this doesnt exist
            
            // if product items exists then add, otherwise increment value
            if(!productItems.ContainsKey(item))
            {
                productItems.Add(item,1);
            }
            else{
                productItems[item]++;
            }
            // add each one to the dictionary, to do next, if item already exists, increase the quantity
        }   
    }
}