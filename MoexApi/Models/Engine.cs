using Newtonsoft.Json;

namespace MoexApi.Models
{
    public class Engine : JsonBase
    {
        [JsonProperty("engines")]
        public Engines Engines { get; set; }
    }

    public class Engines
    {
        [JsonProperty("metadata")]
        public EngineMetadata Metadata { get; set; }

        [JsonProperty("columns")]
        public string[] Columns { get; set; }

        [JsonProperty("data")]
        public object[][] Data { get; set; }
    }

    public class EngineMetadata : MetadataBase
    {

    }
}
