namespace GildedRoseKata
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public Item()
        {
            
        }

        public static Item CreateItem(string name, int sellIn, int quality)
        {
            if (name == "Aged Brie")
            {
                return new AgedBrie(name, sellIn, quality);
            }
            if (name == "Backstage passes to a TAFKAL80ETC concert")
            {
                return new BackStage(name, sellIn, quality);
            }
            if (name == "Sulfuras, Hand of Ragnaros")
            {
                return new Sulfuras(name, sellIn, quality);
            }
            return new Item(name, sellIn, quality);

        }

        public virtual void UpdateQuality()
        {
            if (this.Quality > 1)
            {
                this.Quality = this.Quality - 1;
            }

            this.SellIn = this.SellIn - 1;

            if (this.SellIn < 0)
            {
                if (this.Quality > 0)
                {
                    this.Quality = this.Quality - 1;
                }
            }
        }
    }
}
