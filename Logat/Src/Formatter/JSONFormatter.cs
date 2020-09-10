using System.Text.Json;
using System.Text.Json.Serialization;

namespace TelkomDev.Logat
{
    class JSONFormatter : IFormatter
    {
        public string Format(Log log)
        {
            var options = new JsonSerializerOptions() 
            {
                WriteIndented = false
            };
            return JsonSerializer.Serialize(log, options);
        }
    }
}