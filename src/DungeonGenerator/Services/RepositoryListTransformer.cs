using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace DungeonGenerator.Services
{
    public class RepositoryListTransformer : IRepositoryListTransformer
    {
        // This class should convert the JSON strings into object types.
        // It will be called on from the orchestration layer and take in the data from the IRepository classes
        // T will be MonsterModel or LootModel

        public T TransformJSON<T>(string jsonPayload)
        {
            return JsonConvert.DeserializeObject<T>(jsonPayload);
        }
    }
}
 