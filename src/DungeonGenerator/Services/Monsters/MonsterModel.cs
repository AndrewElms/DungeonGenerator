using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public class MonsterCollection
    {
        public List<MonsterModel> Monsters { get; set; }
    }

    public class MonsterModel
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int NumberOfMonsters { get; set; }
        public int MaxNumberAllowed { get; set; }
    }
}
