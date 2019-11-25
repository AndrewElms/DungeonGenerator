using DungeonGenerator.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    class LootFactory
    {
        // Get a list of loot from the repository, randomly select one and return a loot model

        public LootModel GetLoot(List<LootModel> LootCollection)
        {
            Random random = new Random();
            var randomIndex = random.Next(0, LootCollection.Count);

            return LootCollection[randomIndex];
        }
    }
}
