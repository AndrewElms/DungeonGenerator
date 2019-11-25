using System.IO;
using DungeonGenerator.Infrastructure.Repository;

namespace DungeonGenerator
{
    public class LootRepository: IRepository
    {
        public string GetList()
        {
            // Get the Loot list from the JSON file....but it could be a DynamoDB
            return File.ReadAllText(@"Loot.json");

        }
    }
}
