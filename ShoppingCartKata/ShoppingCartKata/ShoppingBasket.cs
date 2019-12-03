using System.Collections.Generic;

namespace ShoppingCartKata
{
    public class ShoppingBasket
    {
        private readonly string _userId;
        private readonly Item _item;

        public ShoppingBasket(string userId, Item item)
        {
            _userId = userId;
            _item = item;
        }

        public string GetUserId()
        {
            return _userId;
        }

        protected bool Equals(ShoppingBasket other)
        {
            return _userId == other._userId && Equals(_item, other._item);
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
                return ((_userId != null ? _userId.GetHashCode() : 0) * 397) ^ (_item != null ? _item.GetHashCode() : 0);
            }
        }

       
    }
}