using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public class RoomFactory : IRoomFactory
    {
        public RoomModel CreateRoom(int maxWidth, int maxLength)
        {
            Random random = new Random();
            var Room = new RoomModel();

            Room.Width = random.Next(1, maxWidth);
            Room.Length = random.Next(1, maxLength);

            return Room;
        }
    }
}
