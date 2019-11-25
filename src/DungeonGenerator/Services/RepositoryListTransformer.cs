using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator.Services
{
    public class RepositoryListTransformer
    {
        // This class should convert the JSON strings into object types.
        // It will be called on from the orchestration layer and take in the data from the IRepository classes
        // T will be MonsterModel or LootModel
            
        public List<T> TransformJSON<T>(string jsonPayload)
        {
            return JsonConvert.DeserializeObject<List<T>>(jsonPayload);
        }
    }
}
 