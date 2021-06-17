using GildedRose.Console.Rules;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public List<SafeItem> Items { get; set; }
        public List<IRule> Rules { get; set; }

        public Program(List<SafeItem> items)
        {
            Items = items;
            PopulateRuleset();
        }

        private void PopulateRuleset()
        {
            Rules = new List<IRule>
            {
                new Rule_AgedBrieIncrementQuality(),
                new Rule_AgedBrieExpiredIncrementQuality(),
                new Rule_BackstagePassIncrementQuality(),
                new Rule_BackstagePassIncrementQualityWithSellInTenOrLess(),
                new Rule_BackstagePassIncrementQualityWithSellInFiveOrLess(),
                new Rule_BackstagePassZeroQualityWhenExpired(),
                new Rule_DecrementQuality(),
                new Rule_DecrementQualityWhenExpired(),
                new Rule_ConjuredManaCakeDecrementQuality(),
                new Rule_ConjuredManaCakeDecrementQualityWhenExpired(),
                new Rule_DecrementSellIn()
            };
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");
            var app = new Program(GetStandardItems());
            app.UpdateQuality();
            System.Console.ReadKey();
        }

        private static List<SafeItem> GetStandardItems()
        {
            return new List<SafeItem>
            {
                new SafeItem { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new SafeItem { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new SafeItem { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new SafeItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new SafeItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                new SafeItem { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            };
        }

        public void UpdateQuality()
        {
            foreach (SafeItem item in Items)
            {
                foreach (IRule rule in Rules)
                {
                    if (rule.Applies(item))
                    {
                        rule.Invoke(item);
                    }
                }
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}
