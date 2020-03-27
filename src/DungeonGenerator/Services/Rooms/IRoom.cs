using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public interface IRoom
    {
        RoomModel CreateRandomSizedRoom();
    }
}
