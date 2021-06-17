namespace GildedRose.Console.Rules
{
    public class Rule_ConjuredManaCakeDecrementQuality : IRule
    {
        public bool Applies(SafeItem item)
        {
            return item.Name == "Conjured Mana Cake";
        }

        public void Invoke(SafeItem item)
        {
            item.Quality -= 2;
        }
    }
}
