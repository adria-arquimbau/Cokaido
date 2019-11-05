using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var isBackstageItem = item.Name == "Backstage passes to a TAFKAL80ETC concert";
                var isAgedBrieItem = item.Name == "Aged Brie";
                var isSulfurasItem = item.Name == "Sulfuras, Hand of Ragnaros";

                UpdateQuality(isBackstageItem, isSulfurasItem, isAgedBrieItem, item);
            }
        }

        private static void UpdateQuality(bool isBackstageItem, bool isSulfurasItem, bool isAgedBrieItem, Item item)
        {
            if (IsNotAReservedItem(isBackstageItem, isSulfurasItem, isAgedBrieItem) && PositiveQuality(item))
                DecreaseQuality(item);

            if (IsAgedAndBackstage(isBackstageItem, isAgedBrieItem) && MinorThanFiftyQuality(item))
                IncreaseQuality(item);

            if (isBackstageItem && item.SellIn < 11 && MinorThanFiftyQuality(item))
                IncreaseQuality(item);

            if (isBackstageItem && item.SellIn < 6 && MinorThanFiftyQuality(item))
                IncreaseQuality(item);

            if (!isSulfurasItem)
                DecreaseSellIn(item);

            if (IsNotAReservedItem(isBackstageItem, isSulfurasItem, isAgedBrieItem) && NegativeSellIn(item) && PositiveQuality(item))
                DecreaseQuality(item);

            if (isBackstageItem && !isAgedBrieItem && NegativeSellIn(item))
                QualityToZero(item);

            if (isAgedBrieItem && MinorThanFiftyQuality(item) && NegativeSellIn(item))
                IncreaseQuality(item);
        }

        private static bool NegativeSellIn(Item item)
        {
            return item.SellIn < 0;
        }

        private static bool PositiveQuality(Item item)
        {
            return item.Quality > 0;
        }

        private static bool MinorThanFiftyQuality(Item item)
        {
            return item.Quality < 50;
        }

        private static bool IsNotAReservedItem(bool isBackstageItem, bool isSulfurasItem, bool isAgedBrieItem)
        {
            return !isBackstageItem && !isSulfurasItem && !isAgedBrieItem;
        }

        private static bool IsAgedAndBackstage(bool isBackstageItem, bool isAgedBrieItem)
        {
            return isBackstageItem || isAgedBrieItem;
        }

        private static int QualityToZero(Item item)
        {
            return item.Quality = item.Quality - item.Quality;
        }

        private static int DecreaseSellIn(Item item)
        {
            return item.SellIn = item.SellIn - 1;
        }

        private static int DecreaseQuality(Item item)
        {
            return item.Quality = item.Quality - 1;
        }

        private static int IncreaseQuality(Item item)
        {
            return item.Quality = item.Quality + 1;
        }
    }
}