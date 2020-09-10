using System;

namespace TelkomDev.Logat
{
    class PlainFormatter : IFormatter
    {
        public string Format(Log log)
        {
            return $"[{log.AppName}] {log.Timestamp} {log.Level} {log.Message}";
        }
    }
}