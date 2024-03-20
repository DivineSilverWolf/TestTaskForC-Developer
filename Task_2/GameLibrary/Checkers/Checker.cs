using GameLibrary.Exceptions;

namespace GameLibrary.Checkers
{
    public class Checker : IChecker
    {
        private string _secretWord;
        public string? SecretWord {
            get {
                return _secretWord;
            } 
            set {
                CheckerExceptions.ThrowIfNullOrInvalidWord(value);
                _secretWord = value;
            }
        }

        public (bool, string) Check(string stringToCheck)
        {
            CheckerExceptions.ThrowIfNullOrInvalidWord(stringToCheck);
            int cow = _secretWord.Where((c, i) => c != stringToCheck[i] && stringToCheck.Contains(c)).Count();
            int bull = _secretWord.Where((c, i) => c == stringToCheck[i]).Count();
            var (CowString, BullString) = CowAndBullStrings(cow, bull);
            return (bull == 4, $"{cow} «{CowString}» и {bull} «{BullString}»");
        }
        public static (string, string) CowAndBullStrings(int cow, int bull){
            string CowString = cow switch
            {
                0 => "коров",
                1 => "корова",
                _ => "коровы",
            };
            string BullString = bull switch{
                0 => "быков",
                1 => "бык",
                _ => "быка",
            };
            return (CowString, BullString);
        }
    }
}