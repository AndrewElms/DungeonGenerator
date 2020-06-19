namespace DungeonGenerator.Services
{
    public interface IStoryElements
    {
        MonsterModel monster { get; set; }
        LootModel loot { get; set; }
        RoomModel room { get; set; }

        void CreateStoryElements();
    }
}
