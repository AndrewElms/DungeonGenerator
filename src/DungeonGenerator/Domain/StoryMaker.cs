using DungeonGenerator.Services;

namespace DungeonGenerator
{
    // This is the domain logic that knows how to make a story by combining a Room, Loot and Monster
    // Eventually this domain logic could also contain hit point attack calculators and other game mechanics
    public class StoryMaker : IStoryMaker
    {
        public string MakeAStory(IStoryElements storyElements)
        {
            var numberOfMonsters = (storyElements.monster.NumberOfMonsters == 1) ? "a" : storyElements.monster.NumberOfMonsters.ToString();

            var story = $"You stand in a room {storyElements.room.Width}' x {storyElements.room.Length}'.\n"
                        + $"On the far side of the room you see {numberOfMonsters} {storyElements.monster.Name}, \n"
                        + $"guarding a {storyElements.loot.Description}";

            return story;
        }
    }
}
