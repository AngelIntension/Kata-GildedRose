using Xunit;
using GildedRose.Console;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Tests
{
    public class UpdateQualityShould
    {
        [Fact]
        public static void DecrementQualityByOne_GivenNormalItemAndPositiveSellIn()
        {
            List<Item> items = new List<Item> { new Item { Name = "Normal Item", Quality = 10, SellIn = 10 } };
            Program app = new Program(items);

            app.UpdateQuality();

            Assert.Equal(expected: 9, actual: app.Items.First().Quality);
        }
    }
}
