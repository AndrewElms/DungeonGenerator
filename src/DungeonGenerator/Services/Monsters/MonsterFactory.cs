using DungeonGenerator.Infrastructure.Repository;
using DungeonGenerator.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public class MonsterFactory : IMonsterFactory
    {
        // Get a list of monster from the repository, randomly select one and return a monster model
        private readonly IRepositoryListTransformer _transformer;
        private readonly IRepository _repo;

        public MonsterFactory(IRepositoryListTransformer transformer, IRepository repo)
        {
            _transformer = transformer;
            _repo = repo;
        }

        public MonsterModel GetRandomMonster()
        {
            Random random = new Random();
            var monsterCollection = _transformer.TransformJSON<MonsterCollection>(_repo.GetMonsterList());

            var randomIndex = random.Next(0, monsterCollection.Monsters.Count);
            
            var selectedMonster = monsterCollection.Monsters[randomIndex];

            selectedMonster.NumberOfMonsters = random.Next(1, selectedMonster.MaxNumberAllowed);

            return selectedMonster;
        }

    }
}
