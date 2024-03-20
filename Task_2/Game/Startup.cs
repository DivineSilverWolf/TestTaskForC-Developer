using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Game.Config;
using GameLibrary.Games;
using GameLibrary.NumberGeneratorForGames;
using GameLibrary.Checkers;
using GameLibrary.Lots;
using GameLibrary;
namespace Game
{
    internal class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));
            services.AddTransient<IApplicationRunner, ApplicationRunner>();
            var settings = Configuration.GetSection("AppSettings").Get<AppSettings>();
            
            
            if(settings.SelectedGameMode == nameof(settings.GameModes.OnePlayer)){
                services.AddSingleton<AbstractGame, GameForOnePlayer>();
                services.AddTransient<INumberGenerator, FourDigitNumberGenerator>();
                services.AddSingleton<IChecker, Checker>();
            }
            else if(settings.SelectedGameMode == nameof(settings.GameModes.TwoPlayers)){
                services.AddSingleton<AbstractGame, GameForTwoPlayers>();
                services.AddTransient<IChecker>(provider => new Checker());
                
                services.AddSingleton<ILot, LotForTwoPlayers>();
            }
            services.AddSingleton<CountGames>(provaider => new CountGames(settings.PlayCount));
        }


        public IConfiguration Configuration { get; }
    }
}