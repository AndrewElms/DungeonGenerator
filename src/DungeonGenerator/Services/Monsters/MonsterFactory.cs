using DungeonGenerator.Infrastructure.Repository;
using System;

namespace DungeonGenerator
{
    public class MonsterFactory : IMonsterFactory
    {
        private readonly MonsterCollection monsterCollection;
        public int Count { get; }

        public MonsterFactory(IRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("A monster repository must be supplied");

            this.monsterCollection = repository.GetMonsterCollection();
            Count = monsterCollection.Monsters.Count;
        }

        public MonsterModel GetMonster(int monsterID)
        {
            var selectedMonster = monsterCollection.Monsters[monsterID];            
            
            var random = new Random();
            selectedMonster.NumberOfMonsters = random.Next(1, selectedMonster.MaxNumberAllowed);

            return selectedMonster;
        }

    }
}
