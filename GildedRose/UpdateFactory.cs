namespace GildedRose
{
    public class UpdateFactory
    {
        public static IUpdate Create(Item item)
        {
            if (item.Name.Contains("Sulfuras"))
            {
                return new LegendaryUpdate();
            }
            else if (item.Name.Contains("Aged Brie"))
            {
                return new AgedUpdate();
            }
            else if (item.Name.Contains("Backstage pass"))
            {
                return new BackstageUpdate();
            }
            else if (item.Name.Contains("Conjured"))
            {
                return new ConjuredUpdate();
            }
            else
            {
                return new NormalUpdate();
            }
        }
    }
}