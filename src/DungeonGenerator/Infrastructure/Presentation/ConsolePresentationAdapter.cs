using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public class ConsolePresentationAdapter : IPresentation
    {
        // This class should be the presentation layer that in this instance can print the dungeon room details to the console
        public void Print(string roomDetails)
        {
            Console.WriteLine(roomDetails);
        }
    }
}
