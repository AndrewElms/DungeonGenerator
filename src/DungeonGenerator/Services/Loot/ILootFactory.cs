namespace DungeonGenerator
{
    public interface ILootFactory
    {
        int Count { get; }

        LootModel GetLoot(int lootID);
    }
}