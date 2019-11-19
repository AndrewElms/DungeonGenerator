using System;

namespace DungeonGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var consolePresentationAdapter = new ConsolePresentationAdapter();
            var roomFactory = new RoomFactory();
            var dungeonGenerator = new DungenonGeneratorService(consolePresentationAdapter, roomFactory);

            dungeonGenerator.Create();
        }
    }
}
