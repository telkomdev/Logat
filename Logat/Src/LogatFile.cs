namespace TelkomDev.Logat
{
    class LogatFile : AbstractLogat
    {
        private string appName;
        public LogatFile(string appName)
        {
            this.appName = appName;
        }

        public override void Log(Level level, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}