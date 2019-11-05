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

                if (IsNotAReservedItem(isBackstageItem, isSulfurasItem, isAgedBrieItem) && item.Quality > 0)
                    DecreaseQuality(item);
             
                if (IsAgedAndBackstage(isBackstageItem, isAgedBrieItem) && item.Quality < 50)
                    IncreaseQuality(item);

                if (isBackstageItem && item.SellIn < 11 && item.Quality < 50)
                    IncreaseQuality(item);
            
                if (isBackstageItem && item.SellIn < 6 && item.Quality < 50)
                    IncreaseQuality(item);

                if (!isSulfurasItem)
                    DecreaseSellIn(item);
          
                if (IsNotAReservedItem(isBackstageItem, isSulfurasItem, isAgedBrieItem) && item.SellIn < 0 && item.Quality > 0)
                    DecreaseQuality(item);
             
                if (isBackstageItem && !isAgedBrieItem && item.SellIn < 0)
                    QualityToZero(item);

                if (isAgedBrieItem && item.Quality < 50 && item.SellIn < 0)
                    IncreaseQuality(item);
            }
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