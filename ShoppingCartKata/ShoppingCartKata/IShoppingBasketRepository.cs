namespace ShoppingCartKata
{
    public interface IShoppingBasketRepository
    {
        void Save(string userId, string productId, int quantity);
    }
}