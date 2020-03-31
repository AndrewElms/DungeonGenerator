using DungeonGenerator;
using Moq;
using Xunit;

namespace DungeonGeneratorTests
{
    public class StoryMakerTests
    {
        [Fact]
        public void MakeAStory_When_Called_With_Story_Components_A_Single_Story_Is_Produced()
        {
            var stubRoomModel = Mock.Of<RoomModel>();
            stubRoomModel.Length = 1;
            stubRoomModel.Width = 1;

            var stubLootModel = Mock.Of<LootModel>();
            stubLootModel.Description = "Loot";

            var stubMonsterModel = Mock.Of<MonsterModel>();
            stubMonsterModel.NumberOfMonsters = 10;
            stubMonsterModel.Name = "Monsters";    

            var sut = new DungeonGenerator.StoryMaker();

            var storyResult = sut.MakeAStory(stubRoomModel, stubLootModel, stubMonsterModel);

            var TestStory = $"You stand in a room 1' x 1'.\n"
                        + $"On the far side of the room you see 10 Monsters, \n"
                        + $"guarding a Loot";

            Assert.Equal(TestStory, storyResult);
        }

        [Fact]
        public void MakeAStory_When_Called_A_Single_Monster_The_Singluar_Joining_Word_Will_Be_Used()
        {
            var stubRoomModel = Mock.Of<RoomModel>();
            stubRoomModel.Length = 1;
            stubRoomModel.Width = 1;

            var stubLootModel = Mock.Of<LootModel>();
            stubLootModel.Description = "Loot";

            var stubMonsterModel = Mock.Of<MonsterModel>();
            stubMonsterModel.NumberOfMonsters = 1;
            stubMonsterModel.Name = "Monster";

            var sut = new DungeonGenerator.StoryMaker();

            var storyResult = sut.MakeAStory(stubRoomModel, stubLootModel, stubMonsterModel);

            Assert.True(storyResult.Contains("a Monster"));
        }
}
}
