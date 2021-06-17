namespace GildedRose.Console.Rules
{
    public class Rule_DecrementSellIn : IRule
    {
        public bool Applies(SafeItem item)
        {
            return item.Name != "Sulfuras, Hand of Ragnaros";
        }

        public void Invoke(SafeItem item)
        {
            item.SellIn--;
        }
    }
}
