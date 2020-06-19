using DungeonGenerator.Infrastructure.Repository;
using System;

namespace DungeonGenerator
{
    public class LootFactory : ILootFactory
    {
        private readonly LootCollection lootCollection;
        public int Count { get; }

        public LootFactory(IRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("A loot repository must be supplied");

            this.lootCollection = repository.GetLootCollection();
            Count = lootCollection.Loot.Count;
        }

        public LootModel GetLoot(int lootID)
        {
            var selectedLootItem = lootCollection.Loot[lootID];

            return selectedLootItem;
        }
    }
}
