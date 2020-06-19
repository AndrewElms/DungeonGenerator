using DungeonGenerator.Services;
using DungeonGenerator.Infrastructure.Repository;
using System;

namespace DungeonGenerator
{
    // This is the orchestrator
    // Get Config file max width length settings
    // Get a Room object from the RoomFactory
    public class DungeonGeneratorService
    {
        private readonly IPresentation _presentationAdapter;
        private readonly IStoryMaker _storyMaker;
        private readonly IStoryElements _storyElements;

        public DungeonGeneratorService(
            IPresentation presentationAdapter,
            IStoryMaker storyMaker,
            IStoryElements storyElements)
        {
            if (presentationAdapter == null) throw new ArgumentNullException("PresentationAdapter cannot be null");
            _presentationAdapter = presentationAdapter;
           
            if (storyMaker == null) throw new ArgumentNullException("StoryMaker cannot be null");
            _storyMaker = storyMaker;

            if (storyElements == null) throw new ArgumentNullException("StoryElements cannot be null");
            _storyElements = storyElements;

        }

        public void Create()
        {

            while (true)
            {
                _storyElements.CreateStoryElements(); 

                var story = _storyMaker.MakeAStory(_storyElements);

                _presentationAdapter.Print(story);
            }
        }
    }
}
