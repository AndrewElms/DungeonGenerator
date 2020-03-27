using DungeonGenerator.Infrastructure.Repository;
using DungeonGenerator.Services;

namespace DungeonGenerator
{
    // This is the orchestrator    
    public class DungenonGeneratorService
    {
        private readonly IPresentation _presentationAdapter;        
        private readonly IStoryMaker _storyMaker;

        public DungenonGeneratorService(
            IPresentation presentationAdapter,            
            IStoryMaker storyMaker)
        {
            _presentationAdapter = presentationAdapter;            
            _storyMaker = storyMaker;
        }

        public void Create()
        {
            while (true)
            {
                // Use the story maker to combine these elements into a readable story
                var story = _storyMaker.MakeAStory();
                // Output the story
                _presentationAdapter.Print(story);
            }
        }
    }
}