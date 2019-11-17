using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace DungeonGenerator
{
    public class ConfigurationRepository
    {
        public RoomModel GetMaxRoomDimensions()
        {
            var roomModel = new RoomModel();

            roomModel.Width = int.Parse(ConfigurationManager.AppSettings["MaxRoomWidth"]);
            roomModel.Length = int.Parse(ConfigurationManager.AppSettings["MaxRoomLength"]);

            return roomModel;
        }

    }
}
