
namespace DungeonGenerator
{
    public interface ILootFactory
    {
        LootModel GetRandomLoot(LootCollection lootCollection, int randomIndex);
    }
}