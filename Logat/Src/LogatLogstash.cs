namespace TelkomDev.Logat
{
    class LogatLogstash : AbstractLogat
    {
        private string appName;
        public LogatLogstash(string appName)
        {
            this.appName = appName;
        }

        public override void Log(Level level, string message)
        {
            lock (locker)
            {
                
            }
        }

        public override void Close()
        {
            
        }
    }
}