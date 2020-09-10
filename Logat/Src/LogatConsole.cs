using System;
using System.IO;
using Newtonsoft.Json;

namespace TelkomDev.Logat
{
    public class LogatConsole : AbstractLogat
    {
        private string appName;
        private Format format;
        public LogatConsole(string appName, Format format)
        {
            this.appName = appName;
            this.format = format;
        }

        public override void Log(Level level, string message)
        {
            lock (locker)
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

                var timestamp = DateTime.Now.ToString(Constant.DateFormat);

                var standardOutput = new StreamWriter(Console.OpenStandardOutput());
                standardOutput.AutoFlush = true;
                Console.SetOut(standardOutput);

                var log = new Log();
                log.AppName = appName;
                log.Timestamp = timestamp;
                log.Level = level.ToString();
                log.Message = message;
                
                string output = LogFormatter.Format(format, log);

                Console.WriteLine(output);
                Console.ResetColor();
            }
        }

        public override void Close()
        {

        }
    }
}