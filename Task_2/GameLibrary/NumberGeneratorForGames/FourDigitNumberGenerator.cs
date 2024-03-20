namespace GameLibrary.NumberGeneratorForGames
{
    public class FourDigitNumberGenerator : INumberGenerator
    {
        private readonly Random _random = new();
        public int Generate()
        {
            int number;

            do
            {
                number = _random.Next(1000, 10000);
            } while (!IsUnique(number));

            return number;
        }
        private static bool IsUnique(int number)
        {
            string strNumber = number.ToString();
            return strNumber.Distinct().Count() == strNumber.Length;
        }
    }
}