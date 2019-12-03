using System;

namespace ShoppingCartKata
{
    public class Product
    {
        private readonly string _name;
        private readonly double _price;
        private readonly ProductType _productType;

        public Product(string name, double price, ProductType productType)
        {
            _name = name;
            _price = price;
            _productType = productType;
        }
    }

    public enum ProductType
    {
        Dvd,
        Book
    }
}           