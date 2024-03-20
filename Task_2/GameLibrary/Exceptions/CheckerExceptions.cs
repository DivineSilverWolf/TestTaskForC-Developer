using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibrary.Exceptions
{
    public static class CheckerExceptions
    {
        public static void ThrowIfNullOrInvalidWord(this string? value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value.Length != 4)
            {
                throw new ArgumentOutOfRangeException($"Word = {value}. This word consists of {value.Length} letters. The word must consist of 4 letters");
            }

            if (!int.TryParse(value, out _))
            {
                throw new ArgumentException("The word must be a number");
            }

            if (value.Distinct().Count() != value.Length)
            {
                throw new ArgumentException("The word must contain unique digits");
            }
        }
    }
}