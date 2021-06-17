namespace GildedRose.Console.Rules
{
    public class Rule_BackstagePassIncrementQualityWithSellInTenOrLess : IRule
    {
        public bool Applies(SafeItem item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert"
                && item.SellIn > 5
                && item.SellIn <= 10;
        }

        public void Invoke(SafeItem item)
        {
            item.Quality += 2;
        }
    }
}
