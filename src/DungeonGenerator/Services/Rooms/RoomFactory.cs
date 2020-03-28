using DungeonGenerator.Infrastructure.Repository;
using System;

namespace DungeonGenerator
{
    public class RoomFactory : IRoomFactory
    {
        private readonly IRepository _repo;
        private readonly Random _random = new Random();

        public RoomFactory(IRepository repo)
        {
            _repo = repo;
        }

        public RoomModel GetRandomSizedRoom()
        {
            return new RoomModel()
            {
                Width = _random.Next(1, _repo.GetMaxRoomWidth()),
                Length = _random.Next(1, _repo.GetMaxRoomLength())
            };
        }
    }
}