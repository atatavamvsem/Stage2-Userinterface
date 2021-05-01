using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    class GenerateRandomInput
    {
        static readonly Random rndGen = new Random();

        static readonly char[] englishSymbols = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();
        static readonly char[] russianSymbols = "фывапро".ToCharArray();
        static readonly char[] numbers = "123456798".ToCharArray();

        public static String GeneratePassword(int lengthPassword)
        {
            
            string resultPassword = "a";
            resultPassword += GenerateEnglishString(lengthPassword);
            resultPassword += russianSymbols[rndGen.Next(russianSymbols.Length)].ToString();
            resultPassword += numbers[rndGen.Next(numbers.Length)].ToString();
            resultPassword += englishSymbols[rndGen.Next(englishSymbols.Length)].ToString().ToUpper();
            return resultPassword;
        }

        public static String GenerateEmail(int lengthPassword)
        {
            string resultEmail = "a";
            resultEmail += GenerateEnglishString(lengthPassword);
            return resultEmail;
        }

        public static String GenerateDomain(int lengthPassword)
        {
            string resultDomain = "";
            resultDomain += GenerateEnglishString(lengthPassword);
            return resultDomain;
        }

        private static String GenerateEnglishString(int lengthPassword)
        {
            string result = "";
            for (int i = 0; i < lengthPassword; i++)
            {
                result += englishSymbols[rndGen.Next(englishSymbols.Length)].ToString();
            }
            return result;
        }
    }
}
