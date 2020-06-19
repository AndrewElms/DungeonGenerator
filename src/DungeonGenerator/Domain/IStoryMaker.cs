using DungeonGenerator.Services;

namespace DungeonGenerator
{
    public interface IStoryMaker
    {
        string MakeAStory(IStoryElements storyElements);
    }
}