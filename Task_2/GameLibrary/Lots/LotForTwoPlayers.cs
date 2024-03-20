namespace GameLibrary.Lots
{
    public class LotForTwoPlayers : ILot
    {
        private readonly Random random = new();
        public int CastLots()
        {
            return random.Next(0, 2);
        }
    }
}