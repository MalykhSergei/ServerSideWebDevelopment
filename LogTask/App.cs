using System;
using NLog;

namespace LogTask
{
    internal class App
    {
        private static void Main()
        {
            var appLogger = LogManager.GetCurrentClassLogger();

            appLogger.Info("Programm startet");

            var stringsList = Utils.GetStringsListFromFile("1.txt");

            if (stringsList.Count > 0)
            {
                Console.WriteLine($"List of data from file: {string.Join(", ", stringsList)}");
            }

            appLogger.Info("Programm ended");

            Console.ReadKey();
        }
    }
}
