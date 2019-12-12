namespace DungeonGenerator
{
    public interface ILootFactory
    {
        LootModel GetLoot(LootCollection lootCollection);
    }
}