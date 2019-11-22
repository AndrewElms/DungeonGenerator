using System;
using System.Collections.Generic;
using System.Text;
using DungeonGenerator.Infrastructure.Repository;

namespace DungeonGenerator
{
    public class MonsterRepository: IRepository
    {
        public MonsterRepository()
        {

        }

        public string GetList()
        {
            // Get the monster list from the JSON file....but it could be a DynamoDB
            return null;
        }
    }
}
