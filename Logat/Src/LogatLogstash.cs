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
            throw new System.NotImplementedException();
        }
    }
}