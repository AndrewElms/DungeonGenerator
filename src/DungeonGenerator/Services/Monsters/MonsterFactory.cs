using DungeonGenerator.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    class MonsterFactory
    {
        // Get a list of monster from the repository, randomly select one and return a monster model

        public MonsterModel GetMonster(List<MonsterModel> MonsterCollection)
        {
            Random random = new Random();
            var randomIndex = random.Next(0, MonsterCollection.Count);

            return MonsterCollection[randomIndex];
        }

    }
}
