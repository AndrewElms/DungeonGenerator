using System;
using System.Configuration;
using System.Threading.Tasks;
using DungeonGenerator.Infrastructure.Repository;
using DungeonGenerator.Services;
using Microsoft.Extensions.Configuration;
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
            serviceProvider.GetService<DungeonGeneratorService>().Create();
        }

        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IPresentation, ConsolePresentationAdapter>();

            services.AddSingleton<IRepository, Repository>();

            services.AddSingleton<IRoomFactory, RoomFactory>();
            services.AddSingleton<IMonsterFactory, MonsterFactory>();
            services.AddSingleton<ILootFactory, LootFactory>();

            services.AddSingleton<IStoryElements, StoryElements>();

            services.AddSingleton<IStoryMaker, StoryMaker>();

            // Register our application entry point
            services.AddSingleton<DungeonGeneratorService>();

            return services;
        }  
    }
}
