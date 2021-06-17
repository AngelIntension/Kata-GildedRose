using GildedRose.Console.Rules;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public Program(IList<SafeItem> items)
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
                new Rule_DecrementSellIn()
            };
        }

        public IList<SafeItem> Items { get; set; }
        public List<IRule> Rules { get; set; }
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
            for (var i = 0; i < Items.Count; i++)
            {

                if (Items[i].Name == "Aged Brie")
                {
                    // Rules engine
                }
                else if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    Items[i].Quality = Items[i].Quality + 1;

                    if (Items[i].SellIn < 11)
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                    }

                    if (Items[i].SellIn < 6)
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                    }

                    if (Items[i].SellIn <= 0)
                    {
                        Items[i].Quality = 0;
                    }
                }
                else if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
                {
                }
                else
                {
                    Items[i].Quality = Items[i].Quality - 1;
                    if (Items[i].SellIn <= 0)
                    {
                        Items[i].Quality = Items[i].Quality - 1;
                    }
                }

                foreach (IRule rule in Rules)
                {
                    if (rule.Applies(Items[i]))
                    {
                        rule.Invoke(Items[i]);
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
