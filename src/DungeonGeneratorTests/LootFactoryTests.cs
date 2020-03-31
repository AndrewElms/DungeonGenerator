using DungeonGenerator;
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
            
            List<LootModel> fakeLootList = new List<LootModel>();
            fakeLootList.Add(new LootModel("A Shiny Thing", 10));
            fakeLootList.Add(new LootModel("Money", 100));
            fakeLootList.Add(new LootModel("Rusted shield", 1));

            var  lootCollection = new LootCollection(fakeLootList);

            var sut = new LootFactory();
            var result = sut.GetRandomLoot(lootCollection, index);

            Assert.Equal(expected, result.Description);
        }

            
        [Theory]
        [InlineData(10, 0)]
        [InlineData(100, 1)]
        [InlineData(1, 2)]
        public void GetLoot_When_Called_Returns_A_Singular_Item_Value_Of_Loot(int expected, int index)
        {

            List<LootModel> fakeLootList = new List<LootModel>();
            fakeLootList.Add(new LootModel("A Shiny Thing", 10));
            fakeLootList.Add(new LootModel("Money", 100));
            fakeLootList.Add(new LootModel("Rusted shield", 1));

            var lootCollection = new LootCollection(fakeLootList);

            var sut = new LootFactory();
            var result = sut.GetRandomLoot(lootCollection, index);

            Assert.Equal(expected, result.Value);
        }
    }
}
