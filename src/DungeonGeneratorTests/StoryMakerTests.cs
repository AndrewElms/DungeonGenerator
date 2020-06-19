using DungeonGenerator;
using DungeonGenerator.Infrastructure.Repository;
using DungeonGenerator.Services;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace DungeonGeneratorTests
{
    public class StoryMakerTests
    {
        [Fact]
        public void MakeAStory_When_Called_With_Story_Components_A_Single_Story_Is_Produced()
        {
            LootCollection fakeLootCollection = new LootCollection();
            var LootList = new List<LootModel>();
            LootList.Add(new LootModel("Loot", 10));
            fakeLootCollection.Loot = LootList;

            var mockLootRepository = new Mock<IRepository>();
            mockLootRepository
                .Setup(x => x.GetLootCollection())
                .Returns(fakeLootCollection);


            var fakeMonsterCollection = new MonsterCollection();
            var monsterList = new List<MonsterModel>();
            monsterList.Add(new MonsterModel("Monster", 1, 1, 1, 10));
            fakeMonsterCollection.Monsters = monsterList;

            var mockMonsterRepository = new Mock<IRepository>();
            mockMonsterRepository
                    .Setup(x => x.GetMonsterCollection())
                    .Returns(fakeMonsterCollection);

            var stubStoryElements = new StoryElements(
                new MonsterFactory(mockMonsterRepository.Object),
                new LootFactory(mockLootRepository.Object),
                new RoomFactory(1, 1));
            stubStoryElements.CreateStoryElements();

            var sut = new DungeonGenerator.StoryMaker();
            var storyResult = sut.MakeAStory(stubStoryElements);

            var TestStory = $"You stand in a room 1' x 1'.\n"
                        + $"On the far side of the room you see a Monster, \n"
                        + $"guarding a Loot";

            Assert.Equal(TestStory, storyResult);
        }


        [Fact]
        public void MakeAStory_When_Called_With_A_Single_Monster_The_Singluar_Joining_Word_Will_Be_Used()
        {

            LootCollection fakeLootCollection = new LootCollection();
            var LootList = new List<LootModel>();
            LootList.Add(new LootModel("Loot", 10));
            fakeLootCollection.Loot = LootList;

            var mockLootRepository = new Mock<IRepository>();
            mockLootRepository
                .Setup(x => x.GetLootCollection())
                .Returns(fakeLootCollection);


            var fakeMonsterCollection = new MonsterCollection();
            var monsterList = new List<MonsterModel>();
            monsterList.Add(new MonsterModel("Monster", 1, 1, 1, 10));
            fakeMonsterCollection.Monsters = monsterList;

            var mockMonsterRepository = new Mock<IRepository>();
            mockMonsterRepository
                    .Setup(x => x.GetMonsterCollection())
                    .Returns(fakeMonsterCollection);

            var stubStoryElements = new StoryElements(
                new MonsterFactory(mockMonsterRepository.Object), 
                new LootFactory(mockLootRepository.Object), 
                new RoomFactory(10,10));
            stubStoryElements.CreateStoryElements();

            var sut = new StoryMaker();
            var storyResult = sut.MakeAStory(stubStoryElements);

            Assert.Contains("a Monster", storyResult);
        }
    }
}
