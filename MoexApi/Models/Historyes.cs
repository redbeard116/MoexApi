using Newtonsoft.Json;

namespace MoexApi.Models
{
    public class Historyes : JsonBase
    {
        [JsonProperty("history")]
        public Securities History { get; set; }
    }
}
