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
                var someItem = Item.CreateItem(item.Name, item.SellIn, item.Quality);
                someItem.UpdateQuality();
                item.Name = someItem.Name;
                item.Quality = someItem.Quality;
                item.SellIn = someItem.SellIn;
            }
        }
    }

    public class AgedBrie : Item
    {
        public AgedBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            if (this.Quality < 50)
            {
                this.Quality = this.Quality + 1;
            }

            this.SellIn = this.SellIn - 1;

            if (this.SellIn < 0)
            {
                if (this.Quality < 50)
                {
                    this.Quality = this.Quality + 1;
                }
            }
        }
    }

    public class BackStage : Item
    {
        public BackStage(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            if (this.Quality < 50)
            {
                this.Quality = this.Quality + 1;

                if (this.SellIn < 11)
                {
                    if (this.Quality < 50)
                    {
                        this.Quality = this.Quality + 1;
                    }
                }

                if (this.SellIn < 6)
                {
                    if (this.Quality < 50)
                    {
                        this.Quality = this.Quality + 1;
                    }
                }
            }

            this.SellIn = this.SellIn - 1;

            if (this.SellIn < 0)
            {
                this.Quality = this.Quality - this.Quality;
            }
        }
    }

    public class Sulfuras : Item
    {
        public Sulfuras(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
        }
    }
}