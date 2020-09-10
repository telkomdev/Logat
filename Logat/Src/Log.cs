using Newtonsoft.Json;

namespace TelkomDev.Logat
{
    class Log
    {
        [JsonProperty("appName")]
        public string AppName {get; set;}

        [JsonProperty("timestamp")]
        public string Timestamp {get; set;}

        [JsonProperty("level")]
        public string Level {get; set;}

        [JsonProperty("message")]
        public string Message {get; set;}
        public Log()
        {

        }

        
    }
}