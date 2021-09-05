using System;
using NLog;

namespace LogTask
{
    internal class App
    {
        private static void Main()
        {
            var appLogger = LogManager.GetCurrentClassLogger();

            appLogger.Info("Program started");

            var stringsList = Utils.GetStringsListFromFile("1.txt");

            if (stringsList.Count > 0)
            {
                Console.WriteLine($"List of data from file: {string.Join(", ", stringsList)}");
            }

            appLogger.Info("Program ended");

            Console.ReadKey();
        }
    }
}
