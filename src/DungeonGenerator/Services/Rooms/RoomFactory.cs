using DungeonGenerator.Infrastructure.Repository;
using System;

namespace DungeonGenerator
{
    public class RoomFactory : IRoom
    {
        private readonly IRepository _repo;
        public RoomFactory(IRepository repo)
        {
            _repo = repo;
        }

        public RoomModel CreateRandomSizedRoom()
        {
            Random random = new Random();
            return new RoomModel()
            {
                Width = random.Next(1, _repo.GetMaxRoomWidth()),
                Length = random.Next(1, _repo.GetMaxRoomLength())
            };
        }
    }
}