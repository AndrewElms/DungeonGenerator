namespace DungeonGenerator
{
    public interface IMonsterFactory
    {
        MonsterModel GetMonster(MonsterCollection monsterCollection);
    }
}