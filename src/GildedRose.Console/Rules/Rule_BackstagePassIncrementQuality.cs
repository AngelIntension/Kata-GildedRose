namespace GildedRose.Console.Rules
{
    public class Rule_BackstagePassIncrementQuality : IRule
    {
        public bool Applies(SafeItem item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert"
                && item.SellIn > 0;
        }

        public void Invoke(SafeItem item)
        {
            item.Quality++;
        }
    }
}
