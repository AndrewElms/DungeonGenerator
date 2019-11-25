using System.IO;
using DungeonGenerator.Infrastructure.Repository;

namespace DungeonGenerator
{
    public class MonsterRepository: IRepository
    {
        public string GetList()
        {
            // Get the Monster list from the JSON file....but it could be a DynamoDB
            return File.ReadAllText(@"Monsters.json");
        }
    }
}
