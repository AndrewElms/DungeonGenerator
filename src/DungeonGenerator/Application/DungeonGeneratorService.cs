using DungeonGenerator.Services;
using DungeonGenerator.Infrastructure.Repository;
using System;

namespace DungeonGenerator
{
    // This is the orchestrator
    // Get Config file max width length settings
    // Get a Room object from the RoomFactory
    public class DungeonGeneratorService
    {
        private readonly IPresentation _presentationAdapter;
        private readonly IRoom _roomFactory;
        private readonly IRepositoryListTransformer _transformer;
        private readonly IRepository _repository;
        private readonly IMonsterFactory _monsterFactory;
        private readonly ILootFactory _lootFactory;
        private readonly IStoryMaker _storyMaker;

        public DungeonGeneratorService(
            IPresentation presentationAdapter,
            IRoom roomFactory,
            IRepositoryListTransformer transformer,
            IRepository repository,
            IMonsterFactory monsterFactory,
            ILootFactory lootFactory,
            IStoryMaker storyMaker)
        {
            if (presentationAdapter == null) throw new ArgumentNullException("presentationAdapter");
            _presentationAdapter = presentationAdapter;

            if (roomFactory == null) throw new ArgumentNullException("roomFactory");
            _roomFactory = roomFactory;

            if (transformer == null) throw new ArgumentNullException("transformer");
            _transformer = transformer;

            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;

            if (monsterFactory == null) throw new ArgumentNullException("monsterFactory");
            _monsterFactory = monsterFactory;

            if (lootFactory == null) throw new ArgumentNullException("lootFactory");
            _lootFactory = lootFactory;

            if (storyMaker == null) throw new ArgumentNullException("storyMaker");
            _storyMaker = storyMaker;
        }

        public void Create()
        {
            // Get the master lists of things like monsters and loot
            var monsterData = _repository.GetList(@"Monsters.json");   // SMELL: Composition root says this should be done in program and come from app.Config // CHANGE: The repo call to getList<T> should return a collection of <T>, which could be MonsterModel
            var lootData = _repository.GetList(@"Loot.json");          // SMELL and CHANGE as above

            while (true)
            {
                // Create a randomly sized room
                var roomModel = _roomFactory.CreateRoom(10, 10);    // SMELL: Is specifying the max room size is 10x10 here adding domain logic in the application layer?

                // Randomly select a single monster from the master monster list
                var monsters = _transformer.TransformJSON<MonsterCollection>(monsterData);
                var monster = _monsterFactory.GetMonster(monsters);

                // Randomly select a single loot item from the master loot list
                var loot = _transformer.TransformJSON<LootCollection>(lootData);
                var lootIndex = RandomNumberService.GetRandomNumber(loot.Loot.Count);
                var lootItem = _lootFactory.GetRandomLoot(loot, lootIndex);

                // Use the story maker to combine these elements into a readable story
                var story = _storyMaker.MakeAStory(roomModel, lootItem, monster);

                // Output the story
                _presentationAdapter.Print(story);
            }
        }
    }
}
