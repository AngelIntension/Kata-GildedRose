namespace GildedRose.Console.Rules
{
    public class Rule_ConjuredManaCakeDecrementQualityWhenExpired : IRule
    {
        public bool Applies(SafeItem item)
        {
            return item.Name == "Conjured Mana Cake"
                && item.SellIn <= 0;
        }

        public void Invoke(SafeItem item)
        {
            item.Quality -= 4;
        }
    }
}
