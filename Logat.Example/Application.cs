using System;
using System.IO;

namespace TelkomDev.Logat.Example
{
    class Application
    {
        static int Main(string[] args)
        {
            var message = "hello world";
            var logger = new LogatFile("user-service", "user-service.log", Format.JSON);
            var loggerConsole = new LogatConsole("user-service", Format.JSON);
            

            while (true)
            {
                Console.Write("input value : ");
                string value = Console.ReadLine();
                if (value.Equals("exit"))
                {
                    break;
                }

                loggerConsole.Log(Level.WARN, $"{message} : {value}");
                loggerConsole.Log(Level.INFO, $"{message} : {value}");
                loggerConsole.Log(Level.ERROR, $"{message} : {value}");
                
                logger.Log(Level.WARN, $"{message} : {value}");
                logger.Log(Level.INFO, $"{message} : {value}");
                logger.Log(Level.ERROR, $"{message} : {value}");
            }

            /// release resources
            logger.Close();
            return 0;
        }
    }
}
