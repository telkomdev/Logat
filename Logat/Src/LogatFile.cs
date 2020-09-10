using System;
using System.IO;

namespace TelkomDev.Logat
{
    public class LogatFile : AbstractLogat
    {
        private string appName;
        private string fileName;

        private StreamWriter fileOutput;
        public LogatFile(string appName, string fileName)
        {
            this.appName = appName;
            this.fileName = fileName;

            try
            {
                fileOutput = new StreamWriter(fileName, true);
            }
            catch (Exception e)
            {
                throw new IOException(e.ToString());
            }
        }

        public override void Log(Level level, string message)
        {
            lock (locker)
            {
                var datetime = DateTime.Now.ToString("yyyy-mm-dd h:mm:ss");

                ///fileOutput.AutoFlush = true;
                Console.SetOut(fileOutput);
                Console.WriteLine("[{0}] {1} {2} {3}", appName, datetime, level.ToString(), message);
            }
        }

        public override void Close()
        {
            if (fileOutput != null)
            {
                fileOutput.Close();
            }
        }
    }
}