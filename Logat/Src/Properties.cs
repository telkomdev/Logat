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
}