using System;

namespace DungeonGenerator.Services
{
    public class StoryElements: IStoryElements
    {
        private readonly IMonsterFactory monsterFactory;
        private readonly ILootFactory lootFactory;
        private readonly IRoomFactory roomFactory;

        public MonsterModel monster { get; set; }
        public LootModel loot { get; set; }
        public RoomModel room { get; set; }

        public StoryElements(IMonsterFactory monsterFactory, ILootFactory lootFactory, IRoomFactory roomFactory)
        {
            if (monsterFactory == null)
                throw new ArgumentNullException("A monsterFactory must be supplied");

            if (lootFactory == null)
                throw new ArgumentNullException("A lootFactory must be supplied");

            if (roomFactory == null)
                throw new ArgumentNullException("A roomFactory must be supplied");

            this.monsterFactory = monsterFactory;
            this.lootFactory = lootFactory;
            this.roomFactory = roomFactory;
        }

        public void CreateStoryElements()
        {
            Random random = new Random();

            var monsterID = random.Next(0, monsterFactory.Count-1);
            monster = monsterFactory.GetMonster(monsterID);

            var lootID = random.Next(0, lootFactory.Count - 1);
            loot = lootFactory.GetLoot(lootID);

            var roomWidth = random.Next(1, roomFactory.MaxWidth);
            var roomLength = random.Next(1, roomFactory.MaxLength);
            room = roomFactory.CreateRoom(roomWidth, roomLength);

        }
    }
}
