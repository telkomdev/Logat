using System;
using System.IO;

namespace TelkomDev.Logat
{
    public class LogatConsole : AbstractLogat
    {
        private string appName;
        private Format format;

        private StreamWriter standardOutput = null;
        public LogatConsole(string appName, Format format)
        {
            this.appName = appName;
            this.format = format;

            standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
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
                Console.SetOut(standardOutput);

                var log = new Log(){
                    AppName = appName,
                    Timestamp = timestamp,
                    Level = level.ToString(),
                    Message = message
                };
                
                
                string output = LogFormatter.Format(format, log);

                Console.WriteLine(output);
                this.Reset();
            }
        }

        public override void Close()
        {

        }

        protected override void Reset()
        {
            Console.ResetColor();
        }
    }
}