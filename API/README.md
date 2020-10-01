# Supermarket Checkout

## Overview
In this exercise you will implement the code for a supermarket checkout that
calculates the total price of a shopping basket.

Our products are priced individually. However, some products have deals which
give a discount if you buy a certain quanitity. Some products even have more
than one deal available for different quantities.

For example:
- Buy __1__ apple for __£1.00__
- Buy __3__ apples for __£2.00__
- Buy __7__ apples for __£4.20__

Our checkout accepts items in any order, so that if we scan two apples, followed
by a different product and finally a third apple the apple deal should still
apply.

Because our pricing changes frequently, we need to configure each new checkout
instance with the current pricing rules.

## Starting Point
We have provided a Visual Studio solution as a starting point. It includes three
projects. The solution is in a git repo. You should commit your work as you
would normally.

### SupermarketCheckout
This is an empty project where you should provide your implementation.

### SupermarketTests
This is an empty unit test project where you should provide unit tests for your
implementation.

Similar to, but more expansive than:
```c#
[TestClass]
public class SupermarketCheckoutTests
{
    [TestMethod]
    public void Add_Item_To_Pricings_Successfully()
    {
        // Arrange.
        IPricings pricings = new Pricings();

        // Act
        pricings.AddProduct("DIY0001", 6.99f);

        // Assert.
        // No exception was thrown.
        Assert.isTrue(true);
    }
}
```

Think about how you can test your checkout correctly prices deals, etc.

### SupermarketInterfaces
This project contains the two interfaces that must be implemented to make the
checkout work with our systems.

The interfaces are used in other parts of the system and should not be modified
as part of this exercise.

## Exercise
How the checkout is architected is entirely up to you but it must
implement both the provided interfaces. Consider:

- Scanning multiple products.
- Calculating savings from deals.
- Calculating the correct basket total for complex baskets.
- Products having more than one deal available.

### Extra
If you complete the exercise and want to expand on it try thinking about:

- Adding a product to the pricings with an SKU that is already used.
- What if the SKU of two products only differs by case?
- Scanning a product that doesn't exist in the pricings. 
- Removing a product from the basket that doesn't exist. 
- Adding a deal for a product that doesn't exist.
- Where multiple deals are available, is the best combination of deals being
chosen for the quantity?

## When You're Done
When you've completed the exercise or run out of time. Please zip the
`CheckoutExercise` directory in its entirety and return it.
