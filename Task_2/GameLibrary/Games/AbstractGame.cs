namespace GameLibrary.Games
{
    public abstract class AbstractGame(CountGames countPlay)
    {
        protected int CountPlay = countPlay.Count;
        public abstract void StartPlay();
    }
}