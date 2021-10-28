using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseTests
    {
        [Fact]
        public void GivenNormalItem_QualityAfterSellin()
        {
            List<Item> actualItems = new List<Item>()
            {
                new Item { Name = "Bread", SellIn = 0, Quality = 20},
                new Item { Name = "Bread", SellIn = 1, Quality = 20}
            };

            var app = new GildedRose(actualItems);

            app.UpdateQuality();

            Assert.Equal(18, actualItems[0].Quality);
            Assert.Equal(19, actualItems[1].Quality);
        }

        [Fact]
        public void GivenItem_QualityIsNeverNegative()
        {
            List<Item> actualItems = new List<Item>()
            {
                new Item { Name = "Bread", SellIn = -2, Quality = 0}
            };

            var app = new GildedRose(actualItems);

            app.UpdateQuality();

            Assert.Equal(0, actualItems[0].Quality);
        }

        [Fact]
        public void GivenAgedBrie_QualityUpdate()
        {
            List<Item> actualItems = new List<Item>()
            {
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 20}
            };


            var app = new GildedRose(actualItems);

            //  Aged Bries quality should increase by two after it passes its sell by date.
            app.UpdateQuality();

            Assert.Equal(22, actualItems[0].Quality);
        }

        [Fact]
        public void GivenNonLegendaryItem_MaxQuality()
        {
            List<Item> actualItems = new List<Item>()
            {
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 50}
            };


            var app = new GildedRose(actualItems);

            //  Aged Bries quality should increase by two after it passes its sell by date.
            //  However an item that is not a legendary should never surpass a max quality of 50.
            app.UpdateQuality();

            Assert.Equal(50, actualItems[0].Quality);
        }

        [Fact]
        public void GivenLegendary_StatusUpdate()
        {
            List<Item> actualItems = new List<Item>()
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}
            };

            var app = new GildedRose(actualItems);

            //  A legendary should never loose quality and never has to be sold.

            for (int i = 0; i < 100; i++)
            {
                app.UpdateQuality();
            }

            Assert.Equal(80, actualItems[0].Quality);
            Assert.Equal(0, actualItems[0].SellIn);
        }

        [Fact]
        public void GivenBackstagePass_QualityUpdate()
        {
            List<Item> actualItems = new List<Item>()
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 30},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 30},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 30}
            };

            List<Item> expectedItems = new List<Item>()
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 38},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 43},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -2, Quality = 0}
            };

            var app = new GildedRose(actualItems);

            //  "Backstage passes", like aged brie, increases in Quality as it's SellIn
            //  value approaches; Quality increases by 2 when there are 10 days or less
            //  and by 3 when there are 5 days or less but Quality drops to 0 after
            //  the concert

            for (var i = 0; i < 5; i++)
            {
                app.UpdateQuality();
            }

            for (var j = 0; j < actualItems.Count; j++)
            {
                Assert.Equal(expectedItems[j].SellIn, actualItems[j].SellIn);
                Assert.Equal(expectedItems[j].Quality, actualItems[j].Quality);
            }
        }

        [Fact]
        public void GivenConjuredItem_QualityDecrease()
        {
            List<Item> actualItems = new List<Item>()
            {
                new Item { Name = "Conjured Bread", SellIn = 10, Quality = 20},
            };

            var app = new GildedRose(actualItems);

            app.UpdateQuality();

            Assert.Equal(18, actualItems[0].Quality);
        }

        [Fact]
        public void GivenConjuredItem_QualityDecreaseAfterPassedSellIn()
        {
            List<Item> actualItems = new List<Item>()
            {
                new Item { Name = "Conjured Bread", SellIn = 0, Quality = 20},
            };

            var app = new GildedRose(actualItems);

            app.UpdateQuality();

            Assert.Equal(16, actualItems[0].Quality);
        }
    }
}