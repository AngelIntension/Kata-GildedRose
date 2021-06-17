namespace GildedRose.Console.Rules
{
    public class Rule_ConjuredManaCakeDecrementQuality : IRule
    {
        public bool Applies(SafeItem item)
        {
            return item.Name == "Conjured Mana Cake"
                && item.SellIn > 0;
        }

        public void Invoke(SafeItem item)
        {
            item.Quality -= 2;
        }
    }
}
