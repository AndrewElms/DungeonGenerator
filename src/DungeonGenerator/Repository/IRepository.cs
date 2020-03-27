using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator.Infrastructure.Repository
{
    public interface IRepository
    {
        string GetMonsterList();
        string GetLootList();

        int GetMaxRoomLength();
        int GetMaxRoomWidth();
    }
}
