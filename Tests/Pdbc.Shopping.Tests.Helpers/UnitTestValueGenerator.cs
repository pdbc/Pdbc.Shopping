using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdbc.Shopping.Tests.Helpers
{
    public class UnitTestValueGenerator
    {
        private static readonly Random Random = new();

        public const string Alphanumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public const string Numeric = "1234567890";
        public static string Characters = $"{Alphanumeric}{Numeric}";

        public static string GenerateText(int length, string possibleCharacters = null)
        {
            if (possibleCharacters == null)
            {
                possibleCharacters = Characters;
            }

            var code = new string(Enumerable.Repeat(possibleCharacters, length).Select(s => s[Random.Next(s.Length)]).ToArray());
            return code;
        }


        public static long GenerateRandomNumber(int length = 6)
        {
            return long.Parse(GenerateText(length, Numeric));
        }
        public static string GenerateRandomCode(int length = 16)
        {
            return GenerateText(length, Characters);
        }
    }
}
