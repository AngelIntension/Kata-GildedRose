namespace GildedRose.Console.Rules
{
    public class Rule_AgedBrieIncrementQuality : IRule
    {
        public bool Applies(SafeItem item)
        {
            return item.Name == "Aged Brie";
        }

        public void Invoke(SafeItem item)
        {
            item.Quality++;
        }
    }
}
