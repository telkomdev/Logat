namespace TelkomDev.Logat
{
    interface IFormatter
    {
        string Format(Log log);
    }

    static class LogFormatter
    {
        private static IFormatter formatter = null;

        public static string Format(Format format, Log log)
        {
            switch (format)
                {
                    case TelkomDev.Logat.Format.PLAIN:
                        formatter = new PlainFormatter();
                        return formatter.Format(log);
                    case TelkomDev.Logat.Format.JSON:
                        formatter = new JSONFormatter();
                        return formatter.Format(log);
                    default:
                        formatter = new PlainFormatter();
                        return formatter.Format(log);
                }
        }
    }
}