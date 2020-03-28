using DungeonGenerator.Infrastructure.Repository;
using DungeonGenerator.Services;
using System;

namespace DungeonGenerator
{
    public class MonsterFactory : IMonsterFactory
    {
        // Get a list of monster from the repository, randomly select one and return a monster model
        private readonly IRepositoryListTransformer _transformer;

        private readonly IRepository _repo;
        private readonly Random _random = new Random();

        public MonsterFactory(IRepositoryListTransformer transformer, IRepository repo)
        {
            _transformer = transformer;
            _repo = repo;
        }

        public MonsterModel GetRandomMonster()
        {
            var monsterCollection = _transformer.TransformJSON<MonsterCollection>(_repo.GetMonsterList());

            var randomIndex = _random.Next(0, monsterCollection.Monsters.Count);

            var selectedMonster = monsterCollection.Monsters[randomIndex];

            selectedMonster.NumberOfMonsters = _random.Next(1, selectedMonster.MaxNumberAllowed);

            return selectedMonster;
        }
    }
}