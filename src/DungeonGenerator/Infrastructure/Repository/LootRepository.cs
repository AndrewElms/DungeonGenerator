using System;
using System.Collections.Generic;
using System.Text;
using DungeonGenerator.Infrastructure.Repository;

namespace DungeonGenerator
{
    public class LootRepository: IRepository
    {
        public LootRepository()
        {

        }

        public string GetList()
        {
            // Get the Loot list from the JSON file....but it could be a DynamoDB
            return null;
        }
    }
}
