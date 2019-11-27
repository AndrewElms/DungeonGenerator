using DungeonGenerator.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    // This is the orchestrator
    // Get Config file max width length settings
    // Get a Room object from the RoomFactory
    public class DungenonGeneratorService
    {
        private readonly ConsolePresentationAdapter _presentationAdapter;
        private readonly RoomFactory _roomFactory;
        private readonly RepositoryListTransformer _transformer;
        private readonly LootRepository _lootRepo;
        private readonly MonsterRepository _monsterRepo;
        private readonly MonsterFactory _monsterFactory;
        private readonly LootFactory _lootFactory;
        private readonly StoryMaker _storyMaker;

        public DungenonGeneratorService(
            ConsolePresentationAdapter presentationAdapter,
            RoomFactory roomFactory,
            RepositoryListTransformer transformer,
            LootRepository lootRepo,
            MonsterRepository monsterRepo,
            MonsterFactory monsterFactory,
            LootFactory lootFactory,
            StoryMaker storyMaker)
        {
            _presentationAdapter = presentationAdapter;
            _roomFactory = roomFactory;
            _transformer = transformer;
            _lootRepo = lootRepo;
            _monsterRepo = monsterRepo;
            _monsterFactory = monsterFactory;
            _lootFactory = lootFactory;
            _storyMaker = storyMaker;
        }

        public void Create()
        {
            // Get the master lists of things like monsters and loot
            var monsterData = _monsterRepo.GetList();
            var lootData = _lootRepo.GetList();

            while (true)
            {
                // Create a randomly sized room
                var roomModel = _roomFactory.CreateRoom(10, 10);

                // Randomly select a single monster from the master monster list
                var monsters = _transformer.TransformJSON<MonsterCollection>(monsterData);
                var monster = _monsterFactory.GetMonster(monsters);

                // Randomly select a single loot item from the master loot list
                var loot = _transformer.TransformJSON<LootCollection>(lootData);
                var lootItem = _lootFactory.GetLoot(loot);

                // Use the story maker to combine these elements into a readable story
                var story = _storyMaker.MakeAStory(roomModel, lootItem, monster);

                // Output the story
                _presentationAdapter.Print(story);

                Console.ReadLine();
            }
        }
    }
}
