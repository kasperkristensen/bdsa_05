namespace GildedRose
{
    public class ConjuredUpdate : IUpdate
    {
        public void UpdateItem(Item item)
        {

            if (item.Quality > 0)
            {
                item.Quality -= 2;
            }

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality -= 2;
                }
            }

        }
    }
}