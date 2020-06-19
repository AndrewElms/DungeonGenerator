using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator.Infrastructure.Repository
{
    public interface IRepository
    {
        MonsterCollection GetMonsterCollection();
        LootCollection GetLootCollection();
    }
}
