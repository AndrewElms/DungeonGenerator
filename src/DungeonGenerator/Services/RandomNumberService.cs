using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator.Services
{
    public class RandomNumberService
    {
        public static int GetRandomNumber(int maximum)
        {
            Random random = new Random();
            return random.Next(0, maximum);
        }

    }
}
