namespace GildedRose
{

    public class AgedUpdate : IUpdate
    {
        public void UpdateItem(Item item)
        {

            if (item.Quality < 50)
            {
                item.Quality += 1;
            }

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }

        }
    }


}