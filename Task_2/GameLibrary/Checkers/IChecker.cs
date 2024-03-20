using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibrary.Checkers
{
    public interface IChecker
    {
        public string? SecretWord{get; set;}
        public (bool, string) Check(string stringToCheck);
    }
}