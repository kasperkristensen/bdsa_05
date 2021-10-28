using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private IList<Item> Items { get; }

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                IUpdate strategy = UpdateFactory.Create(item);
                strategy.UpdateItem(item);
            }
        }
    }
}