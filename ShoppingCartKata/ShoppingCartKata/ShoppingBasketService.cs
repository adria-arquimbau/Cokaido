using System.Collections.Generic;
using ShoppingCartKata.Tests;

namespace ShoppingCartKata
{
    public class ShoppingBasketService
    {
        private readonly IShoppingBasketRepository _shoppingBasketRepository;

        public ShoppingBasketService(IShoppingBasketRepository shoppingBasketRepository)
        {
            _shoppingBasketRepository = shoppingBasketRepository;
        }

        public void AddItem(string userId, string productId, int quantity)
        {
            var shoppingBasket = new ShoppingBasket(userId, productId, quantity);
            _shoppingBasketRepository.Save(shoppingBasket);
        }   

        public string BasketFor(User userId)
        {
            throw new System.NotImplementedException();
        }
    }
}   