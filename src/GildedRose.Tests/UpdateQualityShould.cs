using Xunit;
using GildedRose.Console;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Tests
{
    public class UpdateQualityShould
    {
        [Fact]
        public static void DecrementQualityByOne_GivenNormalItem()
        {
            Item normalItem = GetNormalItem();
            int initialQuality = normalItem.Quality;
            Program app = new Program(new List<Item> { normalItem });

            app.UpdateQuality();

            Assert.Equal(
                expected: initialQuality - 1,
                actual: normalItem.Quality
                );
        }

        private static Item GetNormalItem()
        {
            return new Item { Name = "Normal Item", Quality = 10, SellIn = 10 };
        }

        [Fact]
        public static void DecrementSellInByOne_GivenNormalItem()
        {
            Item normalItem = GetNormalItem();
            int initialSellIn = normalItem.SellIn;
            Program app = new Program(new List<Item> { normalItem });

            app.UpdateQuality();

            Assert.Equal(
                expected: initialSellIn - 1,
                actual: normalItem.SellIn
                );
        }

        [Fact]
        public static void DecrementQualityByTwo_GivenExpiredNormalItem()
        {
            Item normalItem = GetNormalItem();
            normalItem.SellIn = 0;
            int initialQuality = normalItem.Quality;
            Program app = new Program(new List<Item> { normalItem });

            app.UpdateQuality();

            Assert.Equal(
                expected: initialQuality - 2,
                actual: normalItem.Quality
                );
        }

        [Fact]
        public static void ClampQualityAtZero_GivenNormalItem()
        {
            Item normalItem = GetNormalItem();
            normalItem.Quality = 0;
            Program app = new Program(new List<Item> { normalItem });

            app.UpdateQuality();

            Assert.False(normalItem.Quality < 0);
        }

        [Fact]
        public static void IncrementQualityByOne_GivenAgedBrie()
        {
            Item brie = GetAgedBrie();
            int initialQuality = brie.Quality;
            Program app = new Program(new List<Item> { brie });

            app.UpdateQuality();

            Assert.Equal(
                expected: initialQuality + 1,
                actual: brie.Quality
                );
        }

        private static Item GetAgedBrie()
        {
            return new Item { Name = "Aged Brie", Quality = 10, SellIn = 10 };
        }

        [Fact]
        public static void ClampQualityAt50_GivenAgedBrie()
        {
            Item brie = GetAgedBrie();
            brie.Quality = 50;
            Program app = new Program(new List<Item> { brie });

            app.UpdateQuality();

            Assert.Equal(
                expected: 50,
                actual: brie.Quality
                );
        }

        [Fact]
        public static void NotAffectQuality_GivenSulfuras()
        {
            Item sulfuras = GetSulfuras();
            int initialQuality = sulfuras.Quality;
            Program app = new Program(new List<Item> { sulfuras });

            app.UpdateQuality();

            Assert.Equal(
                expected: initialQuality,
                actual: sulfuras.Quality
                );
        }

        private static Item GetSulfuras()
        {
            return new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        }

        [Fact]
        public static void NotAffectSellIn_GivenSulfuras()
        {
            Item sulfuras = GetSulfuras();
            int initialSellIn = sulfuras.SellIn;
            Program app = new Program(new List<Item> { sulfuras });

            app.UpdateQuality();

            Assert.Equal(
                expected: initialSellIn,
                actual: sulfuras.SellIn
                );
        }

        [Fact]
        public static void IncrementQualityByOne_GivenBackstagePassWithSellInGreaterThanTen()
        {
            Item backstagePass = GetBackstagePass();
            int initialQuality = backstagePass.Quality;
            Program app = new Program(new List<Item> { backstagePass });

            app.UpdateQuality();

            Assert.Equal(
                expected: initialQuality + 1,
                actual: backstagePass.Quality
                );
        }

        private static Item GetBackstagePass()
        {
            return new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
        }

        [Fact]
        public static void ClampQualityAt50_GivenBackstagePass()
        {
            Item backstagePass = GetBackstagePass();
            backstagePass.Quality = 50;
            Program app = new Program(new List<Item> { backstagePass });

            app.UpdateQuality();

            Assert.Equal(
                expected: 50,
                actual: backstagePass.Quality
                );
        }

        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        [InlineData(8)]
        [InlineData(7)]
        [InlineData(6)]
        public static void IncrementQualityByTwo_GivenBackstagePassWithSellInBetweenTenAndFive(int sellIn)
        {
            Item backstagePass = GetBackstagePass();
            backstagePass.SellIn = sellIn;
            int initialQuality = backstagePass.Quality;
            Program app = new Program(new List<Item> { backstagePass });

            app.UpdateQuality();

            Assert.Equal(
                expected: initialQuality + 2,
                actual: backstagePass.Quality
                );
        }

        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public static void IncrementQualityByThree_GivenBackstagePassWithSellInBetweenFiveAndOne(int sellIn)
        {
            Item backstagePass = GetBackstagePass();
            backstagePass.SellIn = sellIn;
            int initialQuality = backstagePass.Quality;
            Program app = new Program(new List<Item> { backstagePass });

            app.UpdateQuality();

            Assert.Equal(
                expected: initialQuality + 3,
                actual: backstagePass.Quality
                );
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        public static void SetQualityToZero_GivenExpiredBackstagePass(int sellIn)
        {
            Item backstagePass = GetBackstagePass();
            backstagePass.SellIn = sellIn;
            Program app = new Program(new List<Item> { backstagePass });

            app.UpdateQuality();

            Assert.Equal(
                expected: 0,
                actual: backstagePass.Quality
                );
        }
    }
}
