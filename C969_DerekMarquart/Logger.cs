using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_DerekMarquart
{
    public class Logger
    {
        public static readonly string logFilePath = "log.txt";

        public static void Log(string message)
        {
            string logMessage = $"{DateTime.Now} - {message}";

            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                writer.WriteLine(logMessage);
            }
        }
    }
}
