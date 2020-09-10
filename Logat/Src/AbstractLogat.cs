namespace TelkomDev.Logat
{
    public abstract class AbstractLogat
    {
        public abstract void Log(Level level, string message);
        
        public abstract void Close();

        /// synchronize call to Log() method
        /// ensure only one thread accesses Log() method
        protected readonly object locker = new object();

        protected abstract void Reset();
    }
}