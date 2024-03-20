using Microsoft.Extensions.Options;
using Game.Config;
using GameLibrary.Games;
namespace Game
{
    internal class ApplicationRunner: IApplicationRunner
    {
        private readonly IOptions<AppSettings> options;
        private readonly AbstractGame _game;

        public ApplicationRunner(IOptions<AppSettings> options, AbstractGame game)
        {
            this._game = game;
            this.options = options;
        }
        public void Run()
        {
            Console.Clear();
            if(options.Value.ShowingAllGameModes)
                options.Value.GameModes.GetType()
                .GetProperties()
                .Select(prop => $"{prop.Name, -10} -> {prop.GetValue(options.Value.GameModes), -1}")
                .ToList()
                .ForEach(Console.WriteLine);

            var greetingMessage = options.Value.ShowingAllGameModes;
            Console.WriteLine("Press Enter to start game");
            _game.StartPlay();
            Console.Title = "IoC Console App";
            Console.WriteLine("Press Enter to exit the application");
            Console.ReadLine();
        }
    }
}