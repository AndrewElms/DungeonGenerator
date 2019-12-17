using System;
using System.Threading.Tasks;
using DungeonGenerator.Infrastructure.Repository;
using DungeonGenerator.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DungeonGenerator
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Following this example for how to add dot net core DI to console app 
            // https://medium.com/swlh/how-to-take-advantage-of-dependency-injection-in-net-core-2-2-console-applications-274e50a6c350

            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<DungenonGeneratorService>().Create();      
        }

        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IPresentation, ConsolePresentationAdapter>();

            services.AddSingleton<IRoom, RoomFactory>();
            services.AddSingleton<IMonsterFactory, MonsterFactory>();
            services.AddSingleton<ILootFactory, LootFactory>();

            services.AddSingleton<IRepositoryListTransformer, RepositoryListTransformer>();
            services.AddSingleton<IRepository, Repository>();

            services.AddSingleton<IStoryMaker, StoryMaker>();

            // Register our application entry point
            services.AddSingleton<DungenonGeneratorService>();

            return services;         
        }



    //var consolePresentationAdapter = new ConsolePresentationAdapter();
                //     var roomFactory = new RoomFactory();
                //     var transformer = new RepositoryListTransformer();
                //     var lootRepo = new LootRepository();
                //     var monsterRepo = new MonsterRepository();
                //     var monsterFactory = new MonsterFactory();
                //     var lootFactory = new LootFactory();
                //     var storyMaker = new StoryMaker();

                //var dungeonGenerator = new DungenonGeneratorService(consolePresentationAdapter, roomFactory, transformer, lootRepo, monsterRepo, monsterFactory, lootFactory, storyMaker);

                //dungeonGenerator.Create();
    }
}
