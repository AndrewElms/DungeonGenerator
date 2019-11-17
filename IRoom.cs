using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public interface IRoom
    {
        RoomModel CreateRoom(int maxWidth, int maxLength);
    }
}
