using System;
using System.Collections.Generic;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using GildedRoseKata;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseAprovalTestShould
    {
        [UseReporter(typeof(DiffReporter))]

        [Fact]
        public void ReturnAllPosibilites()
        {
            string[] name = { "Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Sulfuras, Hand of Ragnaros", "varita1" };
            int[] sellIn = { -32, -14, -9, -1, 0, 1, 3, 5, 6, 7, 10, 11, 12, 49, 50, 52, 60, 78, 89, 120 };
            int[] quality = { -32, -14, -9, -1, 0, 1, 2, 3, 4, 23, 35, 48, 49, 50, 51, 53, 74, 78, 89, 120 };

            CombinationApprovals.VerifyAllCombinations(UpdateQuality, name, sellIn, quality);
        }

        private string UpdateQuality(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();

            return Items[0].Name + ", " + Items[0].SellIn + ", " + Items[0].Quality;
        }
    }
}