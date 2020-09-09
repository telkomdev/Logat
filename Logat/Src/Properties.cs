using System;

namespace TelkomDev.Logat
{
    public enum Target {
        Console,
        File,
        Logstash
    }

    public enum Level {
        INFO,
        DEBUG,
        ERROR,
        WARN
    }
}