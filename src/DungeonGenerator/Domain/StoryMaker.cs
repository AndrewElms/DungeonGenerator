namespace DungeonGenerator
{
    // This is the domain logic that knows how to make a story by combining a Room, Loot and Monster
    // Eventually this domain logic would also contain hit point attack calculators and other game mechanics
    public class StoryMaker : IStoryMaker
    {
        private readonly IRoomFactory _roomFactory;
        private readonly IMonsterFactory _monsterFactory;
        private readonly ILootFactory _lootFactory;

        public StoryMaker(IRoomFactory roomFactory,
            IMonsterFactory monsterFactory,
            ILootFactory lootFactory)
        {
            _roomFactory = roomFactory;
            _monsterFactory = monsterFactory;
            _lootFactory = lootFactory;
        }

        public string MakeAStory()
        {
            var roomModel = _roomFactory.GetRandomSizedRoom();

            var monster = _monsterFactory.GetRandomMonster();

            var loot = _lootFactory.GetRandomLoot();

            var numberOfMonsters = (monster.NumberOfMonsters == 1) ? "a" : monster.NumberOfMonsters.ToString();

            var story = $"You stand in a room {roomModel.Width}' x {roomModel.Length}'.\n"
                        + $"On the far side of the room you see {numberOfMonsters} {monster.Name}, \n"
                        + $"guarding a {loot.Description}";

            return story;
        }
    }
}