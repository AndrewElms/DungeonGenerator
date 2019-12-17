using System.IO;
using DungeonGenerator.Infrastructure.Repository;

namespace DungeonGenerator
{
    public class Repository : IRepository
    {
        public string GetList(string jsonFile)
        {
            // Get the list from the JSON file....but it could be a DynamoDB
            return File.ReadAllText(jsonFile); 
        }
    }
}
