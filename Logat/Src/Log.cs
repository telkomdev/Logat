using System.Text.Json.Serialization;

namespace TelkomDev.Logat
{
    class Log
    {
        [JsonPropertyName("appName")]
        public string AppName {get; set;}

        [JsonPropertyName("timestamp")]
        public string Timestamp {get; set;}

        [JsonPropertyName("level")]
        public string Level {get; set;}

        [JsonPropertyName("message")]
        public string Message {get; set;}
        
        public Log()
        {

        }

        
    }
}