namespace GildedRose.Console
{
    public class SafeItem
    {
        private readonly Item item;
        public string Name { get => item.Name; set => item.Name = value; }
        public int Quality
        {
            get => item.Quality;
            set
            {
                if (value < 0)
                {
                    item.Quality = 0;
                }
                else if(value > 50)
                {
                    item.Quality = 50;
                }
                else
                {
                    item.Quality = value;
                }
            }
        }
        public int SellIn { get => item.SellIn; set => item.SellIn = value; }

        public SafeItem()
        {
            item = new Item();
        }
    }
}
