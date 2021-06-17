namespace GildedRose.Console.Rules
{
    public class Rule_AgedBrieExpiredIncrementQuality : IRule
    {
        public bool Applies(SafeItem item)
        {
            return item.Name == "Aged Brie"
                && item.SellIn <= 0;
        }

        public void Invoke(SafeItem item)
        {
            item.Quality += 2;
        }
    }
}
