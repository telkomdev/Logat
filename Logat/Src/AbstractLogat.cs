namespace TelkomDev.Logat
{
    public abstract class AbstractLogat
    {
        /// synchronize call to Log() method
        /// ensure only one thread accesses Log() method
        protected readonly object locker = new object();
        public abstract void Log(Level level, string message);

        public abstract void Close();
    }
}