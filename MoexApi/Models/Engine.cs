using Newtonsoft.Json;

namespace MoexApi.Models
{
    public class Engine : JsonBase
    {
        [JsonProperty("engines")]
        public Securities Engines { get; set; }
    }
}
