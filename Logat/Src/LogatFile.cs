using System;
using System.IO;
using System.Text;

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

           OpenLogFile();
        }

        private void OpenLogFile()
        {
            try
            {
                //fileName = $"/var/log/{appName}.log";
                FileInfo fileInfo = new FileInfo(fileName);
                FileStream fileStream = fileInfo.Open(FileMode.Append, FileAccess.Write, FileShare.Read);
                fileOutput = new StreamWriter(fileStream, Encoding.UTF8);
            }
            catch (IOException e)
            {
                throw e;
            }
        }

        private void ResetOutputToDefault()
        {
            var sw = new StreamWriter(Console.OpenStandardOutput());
            sw.AutoFlush = true;
            Console.SetOut(sw);
        }

        public override void Log(Level level, string message)
        {
            lock (locker)
            {
                var datetime = DateTime.Now.ToString(Constant.DateFormat);

                ///fileOutput.AutoFlush = true;
                Console.SetOut(fileOutput);
                Console.WriteLine("[{0}] {1} {2} {3}", appName, datetime, level.ToString(), message);

                ResetOutputToDefault();
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