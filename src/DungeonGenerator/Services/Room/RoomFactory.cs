using System;
using System.Configuration;

namespace DungeonGenerator
{
    public class RoomFactory : IRoomFactory
    {

        public int MaxWidth { get; }
        public int MaxLength { get; }       

        public RoomFactory()
        {
            this.MaxWidth = int.Parse(ConfigurationManager.AppSettings["MaxRoomWidth"]);
            this.MaxLength = int.Parse(ConfigurationManager.AppSettings["MaxRoomLength"]);
        }

        public RoomFactory(int maxWidth, int maxLength)
        {
            this.MaxWidth = maxWidth;
            this.MaxLength = maxLength;
        }

        public RoomModel CreateRoom(int width, int length)
        {
            if (width > MaxWidth || length > MaxLength)
                throw new ArgumentException("Supplied room size exceed the maximum allowed value");

            var Room = new RoomModel();

            Room.Width = width;
            Room.Length = length;

            return Room;
        }
    }
}
