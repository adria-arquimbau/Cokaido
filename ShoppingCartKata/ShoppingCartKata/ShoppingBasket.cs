using System.Collections.Generic;

namespace ShoppingCartKata
{
    public class ShoppingBasket
    {
        private readonly string _userId;
        private readonly string _productId;
        private readonly int _quantity;

        public ShoppingBasket(string userId, string productId, int quantity)
        {
            _userId = userId;
            _productId = productId;
            _quantity = quantity;
        }

        public string GetUserId()
        {
            return _userId;
        }

        protected bool Equals(ShoppingBasket other)
        {
            return _userId == other._userId && _productId == other._productId && _quantity == other._quantity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShoppingBasket) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_productId != null ? _productId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _quantity;
                return hashCode;
            }
        }
    }
}