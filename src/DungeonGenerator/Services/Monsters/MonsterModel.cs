using System.Collections.Generic;

namespace DungeonGenerator
{
    public class MonsterCollection
    {
        public List<MonsterModel> Monsters { get; set; }
    }

    public class MonsterModel
    {
        public MonsterModel()
        {
        }

        public MonsterModel(string name, int hitPoints, int numberOfMonsters, int  maxNumberAllowed, int xp)
        {
            Name = name;
            HitPoints = hitPoints;
            NumberOfMonsters = numberOfMonsters;
            MaxNumberAllowed = maxNumberAllowed;
            XP = xp;
        }

        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int NumberOfMonsters { get; set; }
        public int MaxNumberAllowed { get; set; }
        public int XP { get; set; }
    }
}
