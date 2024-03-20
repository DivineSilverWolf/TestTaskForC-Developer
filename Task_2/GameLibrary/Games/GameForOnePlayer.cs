using GameLibrary.Checkers;
using GameLibrary.NumberGeneratorForGames;
using static System.Console;
namespace GameLibrary.Games
{
    public class GameForOnePlayer(CountGames countPlay, INumberGenerator numberGenerator, IChecker checker) : AbstractGame(countPlay)
    {
        private readonly INumberGenerator _numberGenerator = numberGenerator;
        private readonly IChecker _checker = checker;
        private Queue<int> queue = new();
        public override void StartPlay()
        {
            int count = 0;
            while(count ++ != CountPlay){
                _checker.SecretWord = _numberGenerator.Generate().ToString();
                WriteLine($"Раунд {count}! За сколько попыток ты отгодаешь!?");
                Play(1);
            }
            WriteLine("Game Over");
            count = queue.Count;
            for(int i = 1; i <= count; i++){
                WriteLine($"В раунде {i} было потрачено {queue.Dequeue()} попыток");
            }
        }
        private void Play(int attempts){
            try{
                WriteLine("Введите 4-х значное число у которого все цифры отличаются");
                string PlayerMessage = ReadLine()!;
                var (win, messageOut) = _checker.Check(PlayerMessage);
                if(win){
                    WriteLine($"Вы победили! Было потрачено {attempts} попыток!");
                    queue.Enqueue(attempts);
                }
                else{
                    WriteLine(messageOut);
                    Play(attempts + 1);
                }
            }
            catch(Exception e){
                WriteLine(e.Message);
                Play(attempts);
            }
        }
    }
}