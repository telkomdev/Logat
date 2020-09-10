using System;
using System.IO;
using System.Text;

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

                /// flush buffer
                fileOutput.AutoFlush = true;
            }
            catch (IOException e)
            {
                throw e;
            }
        }

        public override void Log(Level level, string message)
        {
            lock (locker)
            {
                var timestamp = DateTime.Now.ToString(Constant.DateFormat);
                
                Console.SetOut(fileOutput);

                var log = new Log(){
                    AppName = appName,
                    Timestamp = timestamp,
                    Level = level.ToString(),
                    Message = message
                };
                
                string output = LogFormatter.Format(format, log);

                Console.WriteLine(output);
                Reset();
            }
        }

        public override void Close()
        {
            if (fileOutput != null)
            {
                fileOutput.Close();
            }
        }

        protected override void Reset()
        {
            var sw = new StreamWriter(Console.OpenStandardOutput());
            sw.AutoFlush = true;
            Console.SetOut(sw);
        }
    }
}