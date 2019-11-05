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
                if (IsNotAReservedItem(item) && item.Quality > 0)
                {
                    item.Quality = DecreaseQuality(item);
                }
                if (IsNotAgedBrieAndBackstage(item) && item.Quality < 50)
                {
                    item.Quality = IncreaseQuality(item);
                }
                if (item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.SellIn < 11 && item.Quality < 50)
                {
                    item.Quality = IncreaseQuality(item);
                }
                if (item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.SellIn < 6 && item.Quality < 50)
                {
                    item.Quality = IncreaseQuality(item);
                }
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn = DecreaseSellIn(item);
                }
                if (IsNotAReservedItem(item) && item.SellIn < 0 && item.Quality > 0)
                {
                    item.Quality = DecreaseQuality(item);
                }
                if (item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.Name != "Aged Brie" && item.SellIn < 0)
                {
                    item.Quality = QualityToZero(item);
                }
                if (item.Name == "Aged Brie" && item.Quality < 50 && item.SellIn < 0)
                {
                    item.Quality = IncreaseQuality(item);
                }
            }
        }

        private static bool IsNotAReservedItem(Item item)
        {
            return item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Name != "Sulfuras, Hand of Ragnaros" && item.Name != "Aged Brie";
        }

        private static int QualityToZero(Item item)
        {
            return item.Quality - item.Quality;
        }

        private static int DecreaseSellIn(Item item)
        {
            return item.SellIn - 1;
        }

        private static int DecreaseQuality(Item item)
        {
            return item.Quality - 1;
        }

        private static int IncreaseQuality(Item item)
        {
            return item.Quality + 1;
        }

        private static bool IsNotAgedBrieAndBackstage(Item item)
        {
            return item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }
    }
}