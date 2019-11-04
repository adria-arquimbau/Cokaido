using System;
using System.Collections.Generic;
using GildedRoseKata;
using Xunit;
using GildedRose = GildedRoseKata.GildedRose;

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

        [Fact]
        public void ReturnVarita1WhenAddNewItemVarita1()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "varita1", SellIn = 0, Quality = 0 } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);

            app.UpdateQuality();

            Assert.Equal("varita1", Items[0].Name);
        }

        [Fact]
        public void ReturnVarita2WhenAddNewItemVarita2AfterOldItemVarita1()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "varita1", SellIn = 0, Quality = 0 } };
            
            Items.Add( new Item { Name = "varita2", SellIn = 0, Quality = 0 });

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal("varita2", Items[1].Name);
        }

        [Fact]
        public void ReturnSellInLess1WhenGivenANewItemVarita1()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "varita1", SellIn = 50, Quality = 0 } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            var sellIn = 50 - 1;

            Assert.Equal(sellIn, Items[0].SellIn);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-50)]
        [InlineData(50)]
        [InlineData(150)]
        [InlineData(25)]
        [InlineData(-25)]
        public void ReturnsTheSameQualityWhenTheNameIsSulfurasHandsOfRagnarosAndAnyValueOfSellIn(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = 10 } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(10, Items[0].Quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-50)]
        [InlineData(50)]
        [InlineData(75)]
        [InlineData(25)]
        [InlineData(-25)]
        public void ReturnsTheSameQualityWhenTheNameIsSulfurasHandsOfRagnarosAndAnyValueOfQuality(int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = quality } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality, Items[0].Quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        [InlineData(-25)]
        [InlineData(-50)]
        [InlineData(-75)]
        public void ReturnsQuality0WhenTheNameIsBackstagePassesToATAFKAL80ETCConcertAndNegativeOrZeroValueOfSellIn(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 10 } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(0, Items[0].Quality);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(15)]
        [InlineData(20)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(75)]
        [InlineData(100)]
        public void ReturnsTheQualityPlusOneWhenTheNameIsBackstagePassesToATAFKAL80ETCConcertAndValueOfSellInIsGreaterThanTen(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 10 } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(11, Items[0].Quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        [InlineData(8)]
        [InlineData(7)]
        [InlineData(6)]
        public void ReturnsTheQualityPlusTwoWhenTheNameIsBackstagePassesToATAFKAL80ETCConcertAndValueOfSellInIsBetweenThanTenAndSix(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 10 } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(12, Items[0].Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void ReturnsTheQualityPlusThreeWhenTheNameIsBackstagePassesToATAFKAL80ETCConcertAndValueOfSellInIsMinorOrEqualThanFive(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 10 } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(13, Items[0].Quality);
        }

        [Theory]
        [InlineData(-75)]
        [InlineData(-50)]
        [InlineData(-25)]
        [InlineData(-5)]
        [InlineData(0)]
        public void ReturnsTheQualityPlusOneWhenTheNameIsAgedBrieAndValueOfSellInIsMinorThanOne(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = 10 } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(12, Items[0].Quality);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(20)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(75)]
        [InlineData(100)]
        public void ReturnsTheQualityPlusOneWhenTheNameIsAgedBrieAndValueOfSellInIsGreaterThanZero(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = 10 } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(11, Items[0].Quality);
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
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(20)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(75)]
        [InlineData(100)]
        public void ReturnsTheQualityLessOneWhenTheNameIsNotAreservedNameAndValueOfSellInIsGreatestThanZero(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Varita1", SellIn = sellIn, Quality = 10 } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(9, Items[0].Quality);
        }

        [Theory]
        [InlineData(-75)]
        [InlineData(-50)]
        [InlineData(-25)]
        [InlineData(-5)]
        [InlineData(0)]
        public void ReturnsTheQualityLessTwoWhenTheNameIsNotAreservedNameAndValueOfSellInIsMinorThanOne(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Varita1", SellIn = sellIn, Quality = 10 } };

            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(8, Items[0].Quality);
        }

    }
}