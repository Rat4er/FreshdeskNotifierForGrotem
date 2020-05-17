using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshdeskNotifier.Logs
{
    public class Logger
    {
        public static void WriteLog(string log)
        {
            string fileName = DateTime.Today.DayOfYear.ToString();
            fileName += ".log";
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.WriteLine(log);
            writer.WriteLine();
            writer.Close();
        }
    }
}
