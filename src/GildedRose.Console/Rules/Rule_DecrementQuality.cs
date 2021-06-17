namespace GildedRose.Console.Rules
{
    public class Rule_DecrementQuality : IRule
    {
        public bool Applies(SafeItem item)
        {
            return item.Name != "Sulfuras, Hand of Ragnaros"
                && item.Name != "Aged Brie"
                && item.Name != "Backstage passes to a TAFKAL80ETC concert";
        }

        public void Invoke(SafeItem item)
        {
            item.Quality--;
        }
    }
}
