namespace DungeonGenerator
{
    public interface IMonsterFactory
    {
        int Count { get; }

        MonsterModel GetMonster(int monsterID);
    }
}