using System;
using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseShould
    {
        [Fact]
        public void ReturnFooWhenAddNewItemFoo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }

        [Theory]
        [InlineData(10, 10)]
        [InlineData(-50, 35)]
        [InlineData(50, 42)]
        [InlineData(150, 31)]
        [InlineData(25, 12)]
        [InlineData(-25, 38)]
        [InlineData(10, 55)]
        [InlineData(-50, 65)]
        [InlineData(50, 72)]
        [InlineData(150, 101)]
        [InlineData(25, 92)]
        [InlineData(-25, 68)]
        public void ReturnsTheSameQualityWhenTheNameIsSulfurasHandsOfRagnarosAndAnyValueOfSellIn(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality, Items[0].Quality);
        }

        [Theory]
        [InlineData(0, 32)]
        [InlineData(-5, 12)]
        [InlineData(-25, 45)]
        [InlineData(-50, 98)]
        [InlineData(-75, 67)]
        public void ReturnsQuality0WhenTheNameIsBackstagePassesToATAFKAL80ETCConcertAndNegativeOrZeroValueOfSellIn(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality - quality, Items[0].Quality);
        }

        [Theory]
        [InlineData(11, 24)]
        [InlineData(12, 10)]
        [InlineData(13, 9)]
        [InlineData(15, 39)]
        [InlineData(20, 34)]
        [InlineData(25, 36)]
        [InlineData(50, 12)]
        [InlineData(75, 43)]
        [InlineData(100, 32)]
        public void ReturnsTheQualityPlusOneWhenTheNameIsBackstagePassesToATAFKAL80ETCConcertAndValueOfSellInIsGreaterThanTen(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality + 1, Items[0].Quality);
        }

        [Theory]
        [InlineData(11, 52)]
        [InlineData(12, 100)]
        [InlineData(13, 69)]
        [InlineData(15, 89)]
        [InlineData(20, 64)]
        [InlineData(25, 76)]
        [InlineData(50, 52)]
        [InlineData(75, 73)]
        [InlineData(100, 92)]
        public void ReturnsTheSameQualityWhenTheNameIsBackstagePassesToATAFKAL80ETCConcertAndValueOfSellInIsGreaterThanTen(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality, Items[0].Quality);
        }

        [Theory]
        [InlineData(10, 10)]
        [InlineData(9, 25)]
        [InlineData(8, 48)]
        [InlineData(7, 32)]
        [InlineData(6, 40)]
        public void ReturnsTheQualityPlusTwoWhenTheNameIsBackstagePassesToATAFKAL80ETCConcertAndValueOfSellInIsBetweenThanTenAndSixAndQuantityMinorThan50(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality + 2, Items[0].Quality);
        }

        [Theory]
        [InlineData(10, 72)]
        [InlineData(9, 100)]
        [InlineData(8, 50)]
        [InlineData(7, 75)]
        [InlineData(6, 51)]
        public void ReturnsTheSameQualityWhenTheNameIsBackstagePassesToATAFKAL80ETCConcertAndValueOfSellInIsBetweenThanTenAndSixAndQuantityIsGreatestThan50(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality, Items[0].Quality);
        }

        [Theory]
        [InlineData(4, 1)]
        [InlineData(3, 10)]
        [InlineData(2, 25)]
        [InlineData(1, 34)]
        public void ReturnsTheQualityPlusThreeWhenTheNameIsBackstagePassesToATAFKAL80ETCConcertAndValueOfSellInIsMinorOrEqualThanFiveAndQuantityIsMinorThan50(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality + 3, Items[0].Quality);
        }

        [Theory]
        [InlineData(4, 51)]
        [InlineData(3, 75)]
        [InlineData(2, 59)]
        [InlineData(1, 64)]
        public void ReturnsTheSameQualityWhenTheNameIsBackstagePassesToATAFKAL80ETCConcertAndValueOfSellInIsMinorOrEqualThanFiveAndQuantityIsHigherThan50(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality, Items[0].Quality);
        }

        [Theory]
        [InlineData(-75, 10)]
        [InlineData(-50, 20)]
        [InlineData(-25, 41)]
        [InlineData(-5, 32)]
        [InlineData(0, 18)]
        public void ReturnsTheQualityPlusOneWhenTheNameIsAgedBrieAndValueOfSellInIsMinorThanOneAndQualityMinorThan50(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality + 2, Items[0].Quality);
        }

        [Theory]
        [InlineData(-75, 55)]
        [InlineData(-50, 63)]
        [InlineData(-25, 79)]
        [InlineData(-5, 100)]
        [InlineData(0, 61)]
        public void ReturnsSameQualityWhenTheNameIsAgedBrieAndValueOfSellInIsMinorThanOneAndQualityHigherThan50(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality, Items[0].Quality);
        }

        [Theory]
        [InlineData(2, 49)]
        [InlineData(5, 32)]
        [InlineData(7, 11)]
        [InlineData(9, 5)]
        [InlineData(10, -14)]
        [InlineData(15, 43)]
        [InlineData(20, 36)]
        [InlineData(25, 25)]
        [InlineData(50, 19)]
        [InlineData(75, 47)]
        [InlineData(100, 32)]
        public void ReturnsTheSameQualityWhenTheNameIsAgedBrieAndValueOfSellInIsGreaterThanZeroAndQualityIsMinorThan50(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality + 1, Items[0].Quality);
        }

        [Theory]
        [InlineData(-75, 50)]
        [InlineData(-50, 52)]
        [InlineData(-25, 770)]
        [InlineData(-5, 50)]
        [InlineData(0, 189)]
        [InlineData(2, 50)]
        [InlineData(5, 50)]
        [InlineData(7, 75)]
        [InlineData(9, 50)]
        [InlineData(10, 50)]
        [InlineData(15, 99)]
        [InlineData(20, 50)]
        [InlineData(25, 100)]
        [InlineData(50, 50)]
        [InlineData(75, 62)]
        [InlineData(100, 50)]
        public void ReturnsTheSameQualityWhenTheNameIsAgedBrieAndQualityIsGreatestThan50(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality, Items[0].Quality);
        }

        [Theory]
        [InlineData(1, 22)]
        [InlineData(3, 5)]
        [InlineData(5, 10)]
        [InlineData(7, 52)]
        [InlineData(9, 50)]
        [InlineData(10, 30)]
        [InlineData(15, 99)]
        [InlineData(20, 10)]
        [InlineData(25, 62)]
        [InlineData(50, 12)]
        [InlineData(75, 58)]
        [InlineData(100, 41)]
        public void ReturnsTheQualityLessOneWhenTheNameIsNotAreservedNameAndValueOfSellInIsGreatestThanZero(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Varita1", SellIn = sellIn, Quality = quality } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality - 1, Items[0].Quality);
        }

        [Theory]
        [InlineData(-75, 22)]
        [InlineData(-50, 65)]
        [InlineData(-25, 87)]
        [InlineData(-5, 43)]
        [InlineData(0, 19)]
        public void ReturnsTheQualityLessTwoWhenTheNameIsNotAreservedNameAndValueOfSellInIsMinorThanOne(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Varita1", SellIn = sellIn, Quality = quality } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality - 2, Items[0].Quality);
        }
    }
}