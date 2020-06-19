namespace DungeonGenerator
{
    public interface IRoomFactory
    {
        int MaxWidth { get; }
        int MaxLength { get; }

        RoomModel CreateRoom(int width, int length);
    }
}
