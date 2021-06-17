namespace GildedRose.Console.Rules
{
    public interface IRule
    {
        bool Applies(SafeItem item);
        void Invoke(SafeItem item);
    }
}
