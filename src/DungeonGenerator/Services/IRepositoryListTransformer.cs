namespace DungeonGenerator.Services
{
    public interface IRepositoryListTransformer
    {
        T TransformJSON<T>(string jsonPayload);
    }
}