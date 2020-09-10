using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace TelkomDev.Logat
{
    public class LogatFile : AbstractLogat
    {
        private string appName;
        private string fileName;
        private Format format;

        private StreamWriter fileOutput = null;
        public LogatFile(string appName, string fileName, Format format)
        {
            this.appName = appName;
            this.fileName = fileName;
            this.format = format;

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
                var timestamp = DateTime.Now.ToString(Constant.DateFormat);

                ///fileOutput.AutoFlush = true;
                Console.SetOut(fileOutput);
                
                var log = new Log();
                log.AppName = appName;
                log.Timestamp = timestamp;
                log.Level = level.ToString();
                log.Message = message;
                
                string output = LogFormatter.Format(format, log);

                Console.WriteLine(output);
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