using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public interface IRoomFactory
    {
        RoomModel CreateRoom(int maxWidth, int maxLength);
    }
}
