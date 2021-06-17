namespace GildedRose.Console.Rules
{
    public class Rule_DecrementQualityWhenExpired : IRule
    {
        public bool Applies(SafeItem item)
        {
            return item.Name != "Sulfuras, Hand of Ragnaros"
                && item.Name != "Aged Brie"
                && item.Name != "Backstage passes to a TAFKAL80ETC concert"
                && item.SellIn <= 0;
        }

        public void Invoke(SafeItem item)
        {
            item.Quality--;
        }
    }
}
