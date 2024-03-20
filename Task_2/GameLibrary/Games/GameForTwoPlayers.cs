using GameLibrary.Checkers;
using GameLibrary.Lots;
using static System.Console;
namespace GameLibrary.Games
{
    public class GameForTwoPlayers(CountGames countPlay, IChecker checkerPlayerOne, IChecker checkerPlayerTwo, ILot lot) : AbstractGame(countPlay)
    {
        private readonly IChecker[] _checkerPlayers = [checkerPlayerOne, checkerPlayerTwo];
        private readonly ILot _lot = lot;
        private InfoGame infoGame = new();
        private struct InfoGame{
            public InfoGame()
            {
            }

            public int FirstPlayerToGuess {get; set;}
            public bool[] GuessingPlayers {get;} = [false, false];
            public int[] PlayersWins{get;} = [0, 0];
        }
        public override void StartPlay()
        {
            int count = 0;
            while (count++ != CountPlay)
            {
                WriteLine($"Раунд {count}! Вы готовы?! Если да, нажмите enter!");
                ReadLine();
                WriteLine("Первый игрок введите четырёхзначное число с отличающимися цифрами!");
                _checkerPlayers[0].SecretWord = GetSecretWord();
                WriteLine("Второй игрок введите четырёхзначное число с отличающимися цифрами!");
                _checkerPlayers[1].SecretWord = GetSecretWord();
                int NumberStartedPlayer = _lot.CastLots();
                ConfigurationInfoGame(NumberStartedPlayer);
                WriteLine($"Первый сходит игрок под номером {NumberStartedPlayer + 1}!");

                Play(NumberStartedPlayer);
                WriteLine($"секретное слово первого игрока: {_checkerPlayers[0].SecretWord}");
                WriteLine($"секретное слово второго игрока: {_checkerPlayers[1].SecretWord}");
            }
            WriteLine($"Конечный счёт: {infoGame.PlayersWins[0]} | {infoGame.PlayersWins[1]}");
        }
        private void Play(int NumberStartedPlayer){
            try{
                WriteLine($"Игрок под номером {NumberStartedPlayer + 1} пробуй угадать!");
                WriteLine("Введи 4-х значное число у которого все цифры отличаются: ");
                string PlayerMessage = ReadLine()!;
                var (win, messageOut) = _checkerPlayers[(NumberStartedPlayer + 1) % 2].Check(PlayerMessage);
                if(win){
                    VictoryScenario(NumberStartedPlayer);
                }
                else if(infoGame.GuessingPlayers[infoGame.FirstPlayerToGuess]){
                    Console.WriteLine("К сожалению вы не угадали... Game over");
                }
                else{
                    WriteLine(messageOut);
                    Play((NumberStartedPlayer + 1) % 2);
                }
            }
            catch(Exception e){
                WriteLine(e.Message);
                Play(NumberStartedPlayer);
            }
        }
        private void VictoryScenario(int NumberStartedPlayer){
            if(infoGame.FirstPlayerToGuess == NumberStartedPlayer){
                WriteLine("Поздравляю, вы угадали! Но позвольте другому игроку сходить последний раз!");
                infoGame.GuessingPlayers[NumberStartedPlayer] = true;
                Play((NumberStartedPlayer + 1) % 2);
            }
            else if(infoGame.GuessingPlayers[infoGame.FirstPlayerToGuess]){
                WriteLine("Ничья!");
            }
            else{
                WriteLine($"Игрок {NumberStartedPlayer + 1} вы победили!");
            }
            infoGame.PlayersWins[NumberStartedPlayer] += 1;
        }
        private void ConfigurationInfoGame(int numberStartedPlayer){
            infoGame.FirstPlayerToGuess = numberStartedPlayer;
            infoGame.GuessingPlayers[0] = false;
            infoGame.GuessingPlayers[1] = false;
        }
        private static string GetSecretWord()
        {
            WriteLine();
            string secretWord = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(intercept: true);
                if (key.Key != ConsoleKey.Enter && secretWord.Length < 4 && char.IsLetterOrDigit(key.KeyChar))
                {
                    secretWord += key.KeyChar;
                    Console.Write("*");
                }
            } while (secretWord.Length < 4);
            WriteLine();
            return secretWord;
        }

    }
}