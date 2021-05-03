using System;

namespace Resources
{
    internal static class Constants
    {
        public const string UrlUserinyerface = "https://userinyerface.com/game.html%20target=";
        public const int lengthInput = 10;
        public const int needingInterests = 3;
        public const string startTimer = "00:00:00";
        public const string imagePath = "C:\\a.png";

        public static string GetNameDirectory(string browser)
        {
            switch (browser)
            {
                case "Chrome":
                    return "Открытие";
                case "Firefox":
                    return "Выгрузка файла";
                default: throw new Exception("Parameter not founded");
            }
        }
    }
}
