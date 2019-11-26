using DungeonGenerator.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public class LootFactory
    {
        // Get a list of loot from the repository, randomly select one and return a loot model

        public LootModel GetLoot(LootCollection lootCollection)
        {
            Random random = new Random();
            var randomIndex = random.Next(0, lootCollection.Loot.Count);

            return lootCollection.Loot[randomIndex];
        }
    }
}
