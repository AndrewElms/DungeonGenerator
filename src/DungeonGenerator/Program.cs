using System;
using DungeonGenerator.Services;

namespace DungeonGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var consolePresentationAdapter = new ConsolePresentationAdapter();
            var roomFactory = new RoomFactory();
            var transformer = new RepositoryListTransformer();
            var lootRepo = new LootRepository();
            var monsterRepo = new MonsterRepository();
            var monsterFactory = new MonsterFactory();
            var lootFactory = new LootFactory();
            var storyMaker = new StoryMaker();

            var dungeonGenerator = new DungenonGeneratorService(consolePresentationAdapter, roomFactory, transformer, lootRepo, monsterRepo, monsterFactory, lootFactory, storyMaker);

            dungeonGenerator.Create();
        }
    }
}
