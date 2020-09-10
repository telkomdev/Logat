using System;

namespace TelkomDev.Logat
{
    public enum Target: byte 
    {
        Console,
        File,
        Logstash
    }

    public enum Level: byte 
    {
        INFO,
        DEBUG,
        ERROR,
        WARN
    }

    public enum Format: byte 
    {
        PLAIN,
        JSON
    }

    static class Constant
    {
        public const string DateFormat = "yyyy-mm-dd h:mm:ss";
    }
}