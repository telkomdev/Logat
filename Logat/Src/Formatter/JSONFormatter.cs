using Newtonsoft.Json;

namespace TelkomDev.Logat
{
    class JSONFormatter : IFormatter
    {
        public string Format(Log log)
        {
            return JsonConvert.SerializeObject(log, Formatting.None);
        }
    }
}