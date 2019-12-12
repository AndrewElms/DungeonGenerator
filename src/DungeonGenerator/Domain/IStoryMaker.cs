namespace DungeonGenerator
{
    public interface IStoryMaker
    {
        string MakeAStory(RoomModel room, LootModel loot, MonsterModel monster);
    }
}