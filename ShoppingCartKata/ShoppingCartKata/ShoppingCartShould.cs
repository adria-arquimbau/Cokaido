using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Xunit;

namespace ShoppingCartKata
{
    public class ShoppingCartShould
    {
        [Fact]
        public void ReturnShoppingBasket()
        {
            //Arrange
            const string expectedUserCart = "- 12/03/2019/n" +
                                            "- 2 x The Hobbit // 2 x 5.00 = £10.00" +
                                            "- 5 x Breaking Bad // 5 x 7.00 = £35.00" +
                                            "- Total: £45.00";

            var shoppingBasketService = new ShoppingBasketService();
            var user = new User();

            var breakingBadProductId = new Product("Breaking Bad", 7.00, ProductType.Dvd);
            var hobbitProductId = new Product("The Hobbit", 5.00, ProductType.Book);

            //Act
            var userId = user.GetId();
            shoppingBasketService.AddItem(userId, hobbitProductId, 2);
            shoppingBasketService.AddItem(userId, breakingBadProductId, 5);

            var userCart = shoppingBasketService.BasketFor(user);
                
            //Assert    
            Assert.Equal(expectedUserCart, userCart);
        }
    }
}   