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
    }
}
