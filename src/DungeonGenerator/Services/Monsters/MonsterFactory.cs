using DungeonGenerator.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public class MonsterFactory : IMonsterFactory
    {
        // Get a list of monster from the repository, randomly select one and return a monster model

        public MonsterModel GetMonster(MonsterCollection monsterCollection)
        {
            Random random = new Random();
            var randomIndex = random.Next(0, monsterCollection.Monsters.Count);

            var selectedMonster = monsterCollection.Monsters[randomIndex];

            selectedMonster.NumberOfMonsters = random.Next(1, selectedMonster.MaxNumberAllowed);

            return selectedMonster;
        }

    }
}
