using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    // This is the orchestrator
    // Get Config file max width length settings
    // Get a Room object from the RoomFactory
    public class DungenonGeneratorService
    {
        private readonly ConsolePresentationAdapter _presentationAdapter;
        private readonly RoomFactory _roomFactory;

        public DungenonGeneratorService(ConsolePresentationAdapter presentationAdapter, RoomFactory roomFactory)
        {
            _presentationAdapter = presentationAdapter;
            _roomFactory = roomFactory;
        }

        public void Create()
        {       
            var roomModel = _roomFactory.CreateRoom(10,10);

            _presentationAdapter.Print($"You stand in a room {roomModel.Width}' x {roomModel.Length}'.");
        }
    }
}
