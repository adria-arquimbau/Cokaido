using Xunit;

namespace ShoppingCartKata.Tests
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

            var shoppingBasketRepository = new ShoppingBasketRepository();

            var shoppingBasketService = new ShoppingBasketService(shoppingBasketRepository);
            var user = new User();

            const string breakingBadProductId = "20110";
            const string hobbitProductId = "10002";

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