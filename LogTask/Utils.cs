using System;
using System.Collections.Generic;
using System.IO;
using NLog;

namespace LogTask
{
    internal class Utils
    {
        public static List<string> GetStringsListFromFile(string fileName)
        {
            var strings = new List<string>();

            var utilsLogger = LogManager.GetCurrentClassLogger();

            try
            {
                using var reader = new StreamReader(fileName);

                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    strings.Add(currentLine);
                }

                utilsLogger.Info("The data was successfully read");
            }
            catch (FileNotFoundException exception)
            {
                utilsLogger.Error(exception, "File is not found");
                utilsLogger.Info("The data from file was not read");
            }
            catch (IOException exception)
            {
                utilsLogger.Error(exception, "I/O error");
                utilsLogger.Info("The data from file was not read");
            }

            return strings;
        }
    }
}

