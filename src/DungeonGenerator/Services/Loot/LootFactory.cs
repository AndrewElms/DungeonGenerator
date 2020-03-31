
namespace DungeonGenerator
{
    public class LootFactory : ILootFactory
    {
        // Get a list of loot from the repository, randomly select one and return a loot model

        public LootModel GetRandomLoot(LootCollection lootCollection, int randomIndex)
        {
            return lootCollection.Loot[randomIndex];
        }
    }
}
