using System;
using System.IO;

namespace TelkomDev.Logat
{
    public class LogatConsole : AbstractLogat
    {
        private string appName;
        public LogatConsole(string appName)
        {
            this.appName = appName;
        }

        public override void Log(Level level, string message)
        {
            switch (level)
            {
                case Level.INFO:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Level.DEBUG:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Level.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Level.WARN:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }

            var datetime = DateTime.Now.ToString("yyyy-mm-dd h:mm:ss");

            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
            Console.WriteLine("[{0}] {1} {2} {3}", appName, datetime, level.ToString(), message);
        }
    }
}