using System;

namespace DungeonGenerator
{
    public class ConsolePresentationAdapter : IPresentation
    {
        // This class should be the presentation layer that in this instance can print the dungeon room details to the console
        public void Print(string story)
        {
            Console.WriteLine(story);
            Console.ReadLine();
        }
    }
}