using DungeonGenerator.Infrastructure.Repository;
using System;
using System.Configuration;
using System.IO;

namespace DungeonGenerator
{
    public class Repository : IRepository
    {
        public string GetMonsterList()
        {
            return ReadFile(ConfigurationManager.AppSettings[Constants.MonsterFileName]);
        }

        public string GetLootList()
        {
            return ReadFile(ConfigurationManager.AppSettings[Constants.LootFileName]);
        }

        public int GetMaxRoomWidth()
        {
            return int.Parse(ConfigurationManager.AppSettings[Constants.MaxRoomWidth]);
        }

        public int GetMaxRoomLength()
        {
            return int.Parse(ConfigurationManager.AppSettings[Constants.MaxRoomLength]);
        }

        private string ReadFile(string fileName)
        {
            try
            {
                return File.ReadAllText(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while trying to load {fileName}. Exception details : {ex}");
                // maybe we want to continue if we failed to load  a file
                // make player's life heaven or hell depending on which file failed (no monster / no loot) :-)
                return string.Empty;
            }
        }
    }
}