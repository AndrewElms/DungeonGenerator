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

        public DungenonGeneratorService(ConsolePresentationAdapter presentationAdapter, RoomFactory roomFactory, RepositoryListTransformer transformer, LootRepository lootRepo, MonsterRepository monsterRepo)
        {
            _presentationAdapter = presentationAdapter;
            _roomFactory = roomFactory;
            _transformer = transformer;
            _lootRepo = lootRepo;
            _monsterRepo = monsterRepo;
        }

        public void Create()
        {
            var MonsterCollection = _monsterRepo.GetList();
            var LootCollection = _lootRepo.GetList();

            var roomModel = _roomFactory.CreateRoom(10,10);
            var Monsters = _transformer.TransformJSON<MonsterModel>(MonsterCollection);
            var Loot = _transformer.TransformJSON<LootModel>(LootCollection);

            _presentationAdapter.Print($"You stand in a room {roomModel.Width}' x {roomModel.Length}'.");
        }
    }
}
