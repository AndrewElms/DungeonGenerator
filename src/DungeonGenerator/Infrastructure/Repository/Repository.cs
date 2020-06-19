using System;
using System.Configuration;
using System.IO;
using DungeonGenerator.Infrastructure.Repository;
using Newtonsoft.Json;

namespace DungeonGenerator
{
    // This implementation of IRepository get data from JSON files....but it could be a replaced by a DynamoDB datasource
    // TODO: Could possibly apply generics here public <T> GetCollection<T>()
    public class Repository : IRepository
    {
        public MonsterCollection GetMonsterCollection()
        {
            var fileName = ConfigurationManager.AppSettings["MonsterFileName"];
            var monsterModel = new MonsterCollection();

            try
            {               
                var monsterData = File.ReadAllText(fileName);
                monsterModel = JsonConvert.DeserializeObject<MonsterCollection>(monsterData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while trying to load {fileName}. Exception details : {ex}");
            }

            return monsterModel;
        }

        public LootCollection GetLootCollection()
        {
            var fileName = ConfigurationManager.AppSettings["LootFileName"];
            var lootCollection = new LootCollection();

            try
            {
                var LootData = File.ReadAllText(fileName);
                lootCollection = JsonConvert.DeserializeObject<LootCollection>(LootData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while trying to load {fileName}. Exception details : {ex}");
            }

            return lootCollection;
        }
    }
}
