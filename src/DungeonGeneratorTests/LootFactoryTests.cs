using DungeonGenerator;
using DungeonGenerator.Infrastructure.Repository;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace DungeonGeneratorTests
{
    public class LootFactoryTests
    {
        [Theory]
        [InlineData("A Shiny Thing", 0)]
        [InlineData("Money", 1)]
        [InlineData("Rusted shield", 2)]
        public void GetLoot_When_Called_Returns_A_Singular_Item_Decription_Of_Loot(string expected, int index)
        {

            LootCollection fakeLootCollection = new LootCollection();

            var LootList = new List<LootModel>();
                LootList.Add(new LootModel("A Shiny Thing", 10));
                LootList.Add(new LootModel("Money", 100));
                LootList.Add(new LootModel("Rusted shield", 1));
            fakeLootCollection.Loot = LootList;

            var mockRepository = new Mock<IRepository>();
            mockRepository
                .Setup(x => x.GetLootCollection())
                .Returns(fakeLootCollection);
          
            var sut = new LootFactory(mockRepository.Object);
            var result = sut.GetLoot(index);

            Assert.Equal(expected, result.Description);
        }

            
        [Theory]
        [InlineData(10, 0)]
        [InlineData(100, 1)]
        [InlineData(1, 2)]
        public void GetLoot_When_Called_Returns_A_Singular_Item_Value_Of_Loot(int expected, int index)
        {

            LootCollection fakeLootCollection = new LootCollection();

            var LootList = new List<LootModel>();
            LootList.Add(new LootModel("A Shiny Thing", 10));
            LootList.Add(new LootModel("Money", 100));
            LootList.Add(new LootModel("Rusted shield", 1));
            fakeLootCollection.Loot = LootList;

            var mockRepository = new Mock<IRepository>();
            mockRepository
                .Setup(x => x.GetLootCollection())
                .Returns(fakeLootCollection);

            var sut = new LootFactory(mockRepository.Object);

            var result = sut.GetLoot(index);

            Assert.Equal(expected, result.Value);
        }
    }
}
