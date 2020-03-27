using DungeonGenerator.Infrastructure.Repository;
using DungeonGenerator.Services;
using System;

namespace DungeonGenerator
{
    public class LootFactory : ILootFactory
    {
        // Get a list of loot from the repository, randomly select one and return a loot model
        private readonly IRepositoryListTransformer _transformer;

        private readonly IRepository _repo;

        public LootFactory(IRepositoryListTransformer transformer, IRepository repo)
        {
            _transformer = transformer;
            _repo = repo;
        }

        public LootModel GetRandomLoot()
        {
            Random random = new Random();
            var lootCollection = _transformer.TransformJSON<LootCollection>(_repo.GetLootList());
            var randomIndex = random.Next(0, lootCollection.Loot.Count);

            return lootCollection.Loot[randomIndex];
        }
    }
}