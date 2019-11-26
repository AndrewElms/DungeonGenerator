using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    // This is the domain logic that knows how to make a story by combining a Room, Loot and Monster
    // Eventually this domain logic would also contain hit point attack calculators and other game mechanics
    public class StoryMaker
    {
        public string MakeAStory(RoomModel room, LootModel loot, MonsterModel monster)
        {
            var story = $"You stand in a room {room.Width}' x {room.Length}'."
                        +$"On the far side of the room you see {if(monster.NumberOfMonsters==1, "a", monster.NumberOfMonsters)} {monster.Name}, "
                        + $"guarding a {loot.Description}";

            return story;
        }
    }
}
