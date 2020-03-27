using System.Collections.Generic;

namespace DungeonGenerator
{
    public class LootCollection
    {
        public List<LootModel> Loot { get; set; }
    }

    public class LootModel
    {
        public string Description { get; set; }
        public int Value { get; set; }
    }
}